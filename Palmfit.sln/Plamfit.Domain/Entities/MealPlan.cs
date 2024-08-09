

using Plamfit.Domain.Entities.Common;
using Plamfit.Domain.Entities.Meals;
using Plamfit.Domain.Enums;

namespace Plamfit.Domain.Entities
{
    public class MealPlan : BaseEntity
    {
        public string Name { get; set; }
        public MealPlanDuration Duration { get; set; }
        public string ImageUrl { get; set; }

        public Dictionary<DayOfWeek, Meal> WeeklyMeals { get; set; }

        public MealPlan()
        {
            WeeklyMeals = new Dictionary<DayOfWeek, Meal>();
        }
    }
}
