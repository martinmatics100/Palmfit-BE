

using Microsoft.Win32;
using Palmfit.Application.Dtos.User;
using Palmfit.Application.Responses;
using Palmfit.Domain.Entities.Users;

namespace Palmfit.Application.Interfaces.IServices
{
    public interface IUserAccountServices
    {
        Task<GeneralResponse> CreateAsync(Register user);
        Task<LoginResponse> SignInAsync(Login user);
        Task<GeneralResponse> SignOutAsync(Guid userId);
        Task<GeneralResponse> UpdateUserAsync(Guid userId, UpdateUser updateUserDto);
        Task<LoginResponse> RefreshTokenAsync(RefreshToken token);
        Task<GeneralResponse> ReAuthenticateAsync(Guid userId);
        Task<DataResponse<IEnumerable<UserDto>>> GetAllUsersAsync();
        Task<DataResponse<UserDto>> GetUserByIdAsync(Guid userId);
        Task<DataResponse<bool>> DeprecateUserAsync(Guid userId);
        Task<DataResponse<bool>> DeleteUserAsync(Guid userId);
        Task<DataResponse<bool>> ActivateUserAsync(Guid userId);
    }
}
