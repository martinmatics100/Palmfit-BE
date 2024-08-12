

using Palmfit.Domain.Entities.Foods;

namespace Palmfit.Domain.Entities.Meals
{
    public class MealFood
    {
        public Food FoodItem { get; set; } 
        public double Quantity { get; set; }
        public double CalorieContent { get; set; }
    }
}
}
