
using Palmfit.Domain.Entities.Common;
using Palmfit.Domain.Entities.Foods;

namespace Palmfit.Domain.Entities.Meals
{
    public class MealFood : BaseEntity
    {
        public Food FoodItem { get; set; } 
        public double Quantity { get; set; }
        public double CalorieContent { get; set; }

        public Guid MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
