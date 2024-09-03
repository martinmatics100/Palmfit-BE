

using Palmfit.Domain.Entities.Common;
using Palmfit.Domain.Entities.Users;
using Palmfit.Domain.Enums;

namespace Palmfit.Domain.Entities.Others
{
    public class Notification : BaseEntity
    {
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        public string Url { get; set; }
        public string Message { get; set; }
        public NotificationType NotificationType { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        public Guid NotificationConfigId { get; set; }
        public NotificationConfig NotificationConfig { get; set; }
    }
}
