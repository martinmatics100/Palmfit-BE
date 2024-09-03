

namespace Palmfit.Application.Responses
{
    public class LoginResponse
    {
        public bool Flag { get; }
        public string Message { get; }
        public string? Token { get; }
        public string? RefreshToken { get; }

        public LoginResponse(bool flag, string message = null, string? token = null, string? refreshToken = null)
        {
            Flag = flag;
            Message = message;
            Token = token;
            RefreshToken = refreshToken;
        }
    }
}
