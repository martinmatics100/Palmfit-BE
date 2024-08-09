using Plamfit.Domain.Entities.Users;
using Plamfit.Domain.Entities.Common;
using Plamfit.Domain.Enums;

namespace Plamfit.Domain.Entities.Payments
{
    public class Subscription : BaseEntity
    {
        public SubscriptionPlan SubscriptionPlan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsExpired { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
