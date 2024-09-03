

using Palmfit.Domain.Entities.Common;
using Palmfit.Domain.Enums;

namespace Palmfit.Domain.Entities.Users
{
    public class UserRole : BaseEntity
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
    }
}
