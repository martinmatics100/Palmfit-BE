using Plamfit.Domain.Entities.Common;
using Plamfit.Domain.Entities.Users;

namespace Plamfit.Domain.Entities.Others
{
    public class Notifications : BaseEntity
    {
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        public string Url { get; set; }
        public string Message { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
