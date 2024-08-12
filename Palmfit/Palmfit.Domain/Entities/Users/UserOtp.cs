

namespace Palmfit.Domain.Entities.Users
{
    public class UserOtp
    {
        public string OTP { get; set; }
        public DateTime Expiration { get; set; }
        public int NoOfAttempts { get; set; }
        public string Email { get; set; }
        public Guid UserId { get; set; } 
    }
}
