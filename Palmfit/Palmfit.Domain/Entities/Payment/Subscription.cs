

using Palmfit.Domain.Entities.Common;
using Palmfit.Domain.Entities.Users;
using Palmfit.Domain.Enums;

namespace Palmfit.Domain.Entities.Payment
{
    public class Subscription : BaseEntity
    {
        public SubscriptionPlan SubscriptionPlan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsExpired { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
