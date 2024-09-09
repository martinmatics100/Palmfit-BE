
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Palmfit.Application.CloudinaryFolder;
using Palmfit.Application.Dtos.User;
using Palmfit.Application.Interfaces.IRepository;
using Palmfit.Application.Interfaces.IServices;
using Palmfit.Application.Responses;
using Palmfit.Common.Helpers;
using Palmfit.Domain.Entities.Users;
using Palmfit.Domain.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Palmfit.Application.Services
{
    public class UserAccountServices : IUserAccountServices
    {
        IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        private readonly IOptions<JwtSection> _config;
        private readonly ICloudinaryService _cloudinaryService;

        public UserAccountServices(IOptions<JwtSection> config, IRepositoryWrapper repositoryWrapper, IMapper mapper, ICloudinaryService cloudinaryService)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
            _cloudinaryService = cloudinaryService ?? throw new ArgumentNullException(nameof(cloudinaryService));

        }
        public async Task<GeneralResponse> CreateAsync(Register user)
        {
            switch (user)
            {
                case null:
                    return new GeneralResponse(false, "Model is empty");

                default:

                    if (user.AcceptsTerms != TermsAndCondition.Accept)
                    {
                        return new GeneralResponse(false, "You must accept the terms and conditions to register.");
                    }


                    var checkUser = await FindUserByEmail(user.Email);
                    if (checkUser != null)
                    {
                        return new GeneralResponse(false, "User already registered");
                    }

                    var newUser = _mapper.Map<AppUser>(user);

                    newUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
                    newUser.CreatedAt = DateTime.UtcNow;
                    newUser.AccountStatus = AccountStatus.Active;

                    await _repositoryWrapper.AppUserRepository.AddAsync(newUser);

                    var roles = await _repositoryWrapper.SystemRoleRepository.GetAllAsync();

                    var checkAdminRole = roles.FirstOrDefault(r => r.Name!.Equals(Constants.Admin));
                    if (checkAdminRole == null)
                    {
                        var createAdminRole = new SystemRole
                        {
                            Name = Constants.Admin 
                        };

                        await _repositoryWrapper.SystemRoleRepository.AddAsync(createAdminRole);
                        await _repositoryWrapper.UserRoleRepository.AddAsync(new UserRole
                        {
                            RoleId = createAdminRole.Id,
                            UserId = newUser.Id
                        });

                        return new GeneralResponse(true, "Account created successfully as Admin");
                    }

                    var checkUserRole = roles.FirstOrDefault(r => r.Name!.Equals(Constants.User));
                    if (checkUserRole == null)
                    {
                        var createUserRole = new SystemRole
                        {
                            Name = Constants.User
                        };

                        await _repositoryWrapper.SystemRoleRepository.AddAsync(createUserRole);
                        await _repositoryWrapper.UserRoleRepository.AddAsync(new UserRole
                        {
                            RoleId = createUserRole.Id,
                            UserId = newUser.Id
                        });
                    }
                    else
                    {
                        await _repositoryWrapper.UserRoleRepository.AddAsync(new UserRole
                        {
                            RoleId = checkUserRole.Id,
                            UserId = newUser.Id
                        });
                    }

                    return new GeneralResponse(true, "Account created successfully");
            }
        }


        public async Task<LoginResponse> SignInAsync(Login user)
        {
            switch (user)
            {
                case null:
                    return new LoginResponse(false, "Model is empty");

                default:

                    var applicationUser = await FindUserByEmail(user.Email);
                    if (applicationUser == null)
                    {
                        return new LoginResponse(false, "User not found");
                    }

                    if (!BCrypt.Net.BCrypt.Verify(user.Password, applicationUser.PasswordHash))
                    {
                        return new LoginResponse(false, "Email/Password not valid");
                    }

                    var getUserRole = await FindUserRole(applicationUser.Id);
                    if (getUserRole == null)
                    {
                        return new LoginResponse(false, "User role not found");
                    }

                    var getRoleName = await FindRoleName(getUserRole.RoleId);
                    if (getRoleName == null)
                    {
                        return new LoginResponse(false, "User role not found");
                    }

                    var jwtToken = GenerateToken(applicationUser, getRoleName.Name);

                    var refreshToken = GenerateRefreshToken();

                    var existingRefreshToken = await _repositoryWrapper.RefreshTokenRepository.GetAllAsync();
                    var findUserToken = existingRefreshToken.FirstOrDefault(_ => _.UserId == applicationUser.Id);

                    if (findUserToken != null)
                    {
                        findUserToken.Token = refreshToken;
                        await _repositoryWrapper.RefreshTokenRepository.UpdateAsync(findUserToken);
                    }
                    else
                    {
                        var newRefreshToken = new RefreshTokenInfo
                        {
                            Token = refreshToken,
                            UserId = applicationUser.Id
                        };
                        await _repositoryWrapper.RefreshTokenRepository.AddAsync(newRefreshToken);
                    }

                    applicationUser.OnlineStatus = OnlineStatus.Online;
                    applicationUser.LastLogin = DateTime.UtcNow;

                    await _repositoryWrapper.AppUserRepository.UpdateAsync(applicationUser);

                    return new LoginResponse(true, "Login successful", jwtToken, refreshToken);
            }
        }

        public async Task<GeneralResponse> SignOutAsync(Guid userId)
        {
            var refreshTokens = await _repositoryWrapper.RefreshTokenRepository.GetAllAsync();
            var userToken = refreshTokens.FirstOrDefault(token => token.UserId == userId && token.IsDeprecated == IsDeprecationStatus.False);

            if (userToken == null)
            {
                return new GeneralResponse(false, "User is not logged in or token is already invalidated");
            }

            await _repositoryWrapper.RefreshTokenRepository.DeprecateAsync(userToken.Id);

            var user = await _repositoryWrapper.AppUserRepository.GetByIdAsync(userId);
            if (user != null)
            {
                user.OnlineStatus = OnlineStatus.Offline;
                user.LastLogin = DateTime.UtcNow;
                await _repositoryWrapper.AppUserRepository.UpdateAsync(user);
            }

            return new GeneralResponse(true, "User logged out successfully");
        }


        public async Task<GeneralResponse> UpdateUserAsync(Guid userId, UpdateUser updateUserDto)
        {
            var user = await _repositoryWrapper.AppUserRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return new GeneralResponse(false, "User not found");
            }

            user.UserName = !string.IsNullOrEmpty(updateUserDto.UserName) ? updateUserDto.UserName : user.UserName;

            if (!string.IsNullOrEmpty(updateUserDto.Email))
            {
                var existingUser = await _repositoryWrapper.AppUserRepository.GetAllAsync();
                var userWithSameEmail = existingUser.FirstOrDefault(u => u.Email.ToLower() == updateUserDto.Email.ToLower());

                if (userWithSameEmail != null && userWithSameEmail.Id != userId)
                {
                    return new GeneralResponse(false, "Email is already in use by another user");
                }

                user.Email = updateUserDto.Email;
            }

            user.ImageUrl = updateUserDto.Image != null
                            ? await _cloudinaryService.UploadImageAsync(updateUserDto.Image)
                            : user.ImageUrl;

            user.PhoneNumber = !string.IsNullOrEmpty(updateUserDto.PhoneNumber) ? updateUserDto.PhoneNumber : user.PhoneNumber;
            user.Street = !string.IsNullOrEmpty(updateUserDto.Street) ? updateUserDto.Street : user.Street;
            user.City = !string.IsNullOrEmpty(updateUserDto.City) ? updateUserDto.City : user.City;
            user.State = !string.IsNullOrEmpty(updateUserDto.State) ? updateUserDto.State : user.State;
            user.PostalCode = !string.IsNullOrEmpty(updateUserDto.PostalCode) ? updateUserDto.PostalCode : user.PostalCode;
            user.Country = !string.IsNullOrEmpty(updateUserDto.Country) ? updateUserDto.Country : user.Country;

            user.Height = updateUserDto.Height.HasValue ? updateUserDto.Height.Value : user.Height;
            user.HeightUnit = updateUserDto.HeightUnit.HasValue ? updateUserDto.HeightUnit.Value : user.HeightUnit;
            user.Weight = updateUserDto.Weight.HasValue ? updateUserDto.Weight.Value : user.Weight;
            user.WeightUnit = updateUserDto.WeightUnit.HasValue ? updateUserDto.WeightUnit.Value : user.WeightUnit;
            user.ActivityLevel = updateUserDto.ActivityLevel.HasValue ? updateUserDto.ActivityLevel.Value : user.ActivityLevel;
            user.FitnessLevel = updateUserDto.FitnessLevel.HasValue ? updateUserDto.FitnessLevel.Value : user.FitnessLevel;
            user.WeightGoal = updateUserDto.WeightGoal.HasValue ? updateUserDto.WeightGoal.Value : user.WeightGoal;
            user.Gender = updateUserDto.Gender.HasValue ? updateUserDto.Gender.Value : user.Gender;
            user.DateOfBirth = updateUserDto.DateOfBirth.HasValue ? updateUserDto.DateOfBirth.Value.ToUniversalTime() : user.DateOfBirth;

            await _repositoryWrapper.AppUserRepository.UpdateAsync(user);

            return new GeneralResponse(true, "User updated successfully");
        }




        private async Task<UserRole> FindUserRole(Guid userId)
        {
            var userRoles = await _repositoryWrapper.UserRoleRepository.GetAllAsync();
            return userRoles.FirstOrDefault(ur => ur.UserId == userId);
        }

        private async Task<SystemRole> FindRoleName(Guid roleId)
        {
            return await _repositoryWrapper.SystemRoleRepository.GetByIdAsync(roleId);
        }

        private static string GenerateRefreshToken() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        private async Task<AppUser> FindUserByEmail(string email)
        {
            var lowerCaseEmail = email.ToLower();

            var users = await _repositoryWrapper.AppUserRepository.GetAllAsync();
            return users.FirstOrDefault(u => u.Email.ToLower().Equals(lowerCaseEmail));
        }

        private string GenerateToken(AppUser user, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Value.Key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Name, user.LastName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role)
            };
            var token = new JwtSecurityToken(
                issuer: _config.Value.Issuer,
                audience: _config.Value.Audience,
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(20),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task<GeneralResponse> ReAuthenticateAsync(Guid userId)
        {
            var user = await _repositoryWrapper.AppUserRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return new GeneralResponse(false, "User not found");
            }

            var refreshToken = await _repositoryWrapper.RefreshTokenRepository.GetAllAsync();
            var userToken = refreshToken.FirstOrDefault(t => t.UserId == userId && t.IsDeprecated == IsDeprecationStatus.False);

            if (userToken == null)
            {
                return new GeneralResponse(false, "User session has expired or is invalid");
            }

            var userRole = await FindUserRole(user.Id);
            var roleName = await FindRoleName(userRole.RoleId);
            var jwtToken = GenerateToken(user, roleName.Name);

            return new GeneralResponse(true, jwtToken);
        }

        public async Task<LoginResponse> RefreshTokenAsync(RefreshToken token)
        {
            if (token == null)
            {
                return new LoginResponse(false, "Model is empty");
            }

            var findToken = await _repositoryWrapper.RefreshTokenRepository.GetAllAsync();
            var existingToken = findToken.FirstOrDefault(_ => _.Token.Equals(token.Token));

            if (existingToken == null)
            {
                return new LoginResponse(false, "Refresh token is required");
            }

            var user = await _repositoryWrapper.AppUserRepository.GetByIdAsync(existingToken.UserId);
            if (user == null)
            {
                return new LoginResponse(false, "Refresh token could not be generated because user was not found");
            }

            var userRole = await FindUserRole(user.Id);
            var roleName = await FindRoleName(userRole.RoleId);

            string jwtToken = GenerateToken(user, roleName.Name);
            string refreshToken = GenerateRefreshToken();

            existingToken.Token = refreshToken;
            await _repositoryWrapper.RefreshTokenRepository.UpdateAsync(existingToken);

            return new LoginResponse(true, "Token refreshed successfully", jwtToken, refreshToken);
        }

        public async Task<DataResponse<IEnumerable<UserDto>>> GetAllUsersAsync()
        {
            var users = await _repositoryWrapper.AppUserRepository.GetAllAsync();
            var userRoles = await _repositoryWrapper.UserRoleRepository.GetAllAsync();

            // Await the task to get the list of roles
            var roles = await _repositoryWrapper.SystemRoleRepository.GetAllAsync();

            var adminRole = roles.FirstOrDefault(r => r.Name == Constants.Admin);

            IEnumerable<UserDto> userDtos;

            if (adminRole != null)
            {
                var adminUserIds = userRoles
                    .Where(ur => ur.RoleId == adminRole.Id)
                    .Select(ur => ur.UserId)
                    .ToHashSet();
                var nonAdminUsers = users.Where(u => !adminUserIds.Contains(u.Id) && u.IsDeprecated == IsDeprecationStatus.False);

                userDtos = _mapper.Map<IEnumerable<UserDto>>(nonAdminUsers);

                return new DataResponse<IEnumerable<UserDto>>(true, "", userDtos);
            }
            else
            {
                var nonDeprecatedUsers = users.Where(u => u.IsDeprecated == IsDeprecationStatus.False);
                userDtos = _mapper.Map<IEnumerable<UserDto>>(nonDeprecatedUsers);

                return new DataResponse<IEnumerable<UserDto>>(true, "No users found", userDtos);
            }       
        }

        public async Task<DataResponse<UserDto>> GetUserByIdAsync(Guid userId)
        {
            var user = await _repositoryWrapper.AppUserRepository.GetByIdAsync(userId);

            if (user == null || user.IsDeprecated == IsDeprecationStatus.True)
            {
                return new DataResponse<UserDto>(false, "User not found or deprecated");
            }

            var userDto = _mapper.Map<UserDto>(user);

            return new DataResponse<UserDto>(true, "", userDto);
        }

        public async Task<DataResponse<bool>> DeprecateUserAsync(Guid userId)
        {
            await _repositoryWrapper.AppUserRepository.DeprecateAsync(userId);

            return new DataResponse<bool>(true, "User has been deprecated successfully");
        }

        public async Task<DataResponse<bool>> DeleteUserAsync(Guid userId)
        {
            var user = await _repositoryWrapper.AppUserRepository.GetByIdAsync(userId);

            if (user == null)
            {
                return new DataResponse<bool>(false, "User not found");
            }

            await _repositoryWrapper.AppUserRepository.DeleteAsync(user);

            return new DataResponse<bool>(true, "User has been deleted successfully");
        }
        public async Task<DataResponse<bool>> ActivateUserAsync(Guid userId)
        {
            await _repositoryWrapper.AppUserRepository.ActivateAsync(userId);

            return new DataResponse<bool>(true, "User has been activated successfully");
        }
    }
}
