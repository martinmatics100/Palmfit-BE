

using Palmfit.Domain.Entities.Common;
using Palmfit.Domain.Entities.Foods;
using Palmfit.Domain.Enums;

namespace Palmfit.Domain.Entities.Meals
{
    public class Meal : BaseEntity
    {
        public string Name { get; set; } // e.g., Breakfast, Lunch, Dinner
        public DayOfTheWeek DayOfTheWeek { get; set; }
        public ICollection<MealFood> MealFoods { get; set; }

    }
}
