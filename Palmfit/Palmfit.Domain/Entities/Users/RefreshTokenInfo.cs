

using Palmfit.Domain.Entities.Common;

namespace Palmfit.Domain.Entities.Users
{
    public class RefreshTokenInfo : BaseEntity
    {
        public string? Token { get; set; }
        public Guid UserId { get; set; }
    }
}
