

using Palmfit.Domain.Entities.Common;
using Palmfit.Domain.Entities.Foods;
using Palmfit.Domain.Entities.Users;
using Palmfit.Domain.Enums;

namespace Palmfit.Domain.Entities.Meals
{
    public class MealPlan : BaseEntity
    {
        public string Name { get; set; }
        public MealPlanDuration Duration { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<AppUser> Users { get; set; }

        public ICollection<Food> Foods { get; set; }

        public Dictionary<DayOfTheWeek, Meal> WeeklyMeals { get; set; }

        public MealPlan()
        {
            WeeklyMeals = new Dictionary<DayOfTheWeek, Meal>();
        }
    }
}
