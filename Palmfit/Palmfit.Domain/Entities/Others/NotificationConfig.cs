

using Palmfit.Domain.Entities.Common;
using Palmfit.Domain.Enums;

namespace Palmfit.Domain.Entities.Others
{
    public class NotificationConfig : BaseEntity
    {
        public NotificationType NotificationType { get; set; }
        public string Description { get; set; }  // Description of what the notification is about
        public bool IsActive { get; set; }  // Indicates if this notification type is currently active
        public TimeSpan Frequency { get; set; }  // Frequency of sending notifications (e.g., daily, weekly)
        public DateTime LastSent { get; set; }  // Last time this type of notification was sent
    }
}
