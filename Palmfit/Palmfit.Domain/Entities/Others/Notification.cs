

using Palmfit.Domain.Entities.Common;
using Palmfit.Domain.Entities.Users;

namespace Palmfit.Domain.Entities.Others
{
    public class Notification : BaseEntity
    {
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        public string Url { get; set; }
        public string Message { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
