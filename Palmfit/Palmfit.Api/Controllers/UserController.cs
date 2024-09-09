using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Application.Dtos.User;
using Palmfit.Application.Interfaces.IServices;
using System.Security.Claims;

namespace Palmfit.Api.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAccountServices _userAccountServices;


        public UserController(IUserAccountServices userAccountServices)
        {
            _userAccountServices = userAccountServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] Register request)
        {
            var result = await _userAccountServices.CreateAsync(request);
            return Ok(result.Message);
        }

        [HttpPost("login")]
        public async Task<IActionResult> SignIn([FromForm] Login request)
        {
            var result = await _userAccountServices.SignInAsync(request);
            return Ok(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> SignOut([FromForm] Guid userId)
        {
            var result = await _userAccountServices.SignOutAsync(userId);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromForm] UpdateUser updateUserDto)
        {
            var result = await _userAccountServices.UpdateUserAsync(userId, updateUserDto);
            if (!result.Flag)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }

        [HttpPost("reauthenticate")]
        public async Task<IActionResult> ReAuthenticate([FromForm] ReauthenticateRequest request)
        {

            var response = await _userAccountServices.ReAuthenticateAsync(request.UserId);

            if (response.Flag)
            {
                return Ok(response);
            }

            return Unauthorized(response.Message);
        }

        [HttpGet("get-users")]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userAccountServices.GetAllUsersAsync();

            if (!response.Flag)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Data);
        }

        [HttpGet("get-user/{id}/")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var response = await _userAccountServices.GetUserByIdAsync(id);

            if (!response.Flag)
            {
                return NotFound(new { message = response.Message });
            }

            return Ok(response.Data);
        }

        [HttpPost("deprecate/{id}")]
        public async Task<IActionResult> DeprecateUser(Guid id)
        {
            var result = await _userAccountServices.DeprecateUserAsync(id);
            if (!result.Flag)
            {
                return BadRequest(result.Message);
            }
            return Ok();
        }

        [HttpPost("activate/{id}")]
        public async Task<IActionResult> ActivateUser(Guid id)
        {
            var result = await _userAccountServices.ActivateUserAsync(id);
            if (!result.Flag)
            {
                return BadRequest(result.Message);
            }
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _userAccountServices.DeleteUserAsync(id);
            if (!result.Flag)
            {
                return BadRequest(result.Message);
            }
            return Ok();
        }
    }
}
