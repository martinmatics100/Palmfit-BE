

using Palmfit.Domain.Entities.Common;
using Palmfit.Domain.Entities.Users;

namespace Palmfit.Domain.Entities.Meals
{
    public class UserMealPlan : BaseEntity
    {
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public Guid MealPlanId { get; set; }
        public MealPlan MealPlan { get; set; }

        public DateTime DateJoined { get; set; }
    }
}
