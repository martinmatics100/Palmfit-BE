using Plamfit.Domain.Enums;
using Plamfit.Domain.Entities.Common;

namespace Plamfit.Domain.Entities.Meals
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
