

using Palmfit.Domain.Entities.Common;

namespace Palmfit.Domain.Entities.Users
{
    public class Invite : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
