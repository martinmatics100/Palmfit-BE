

using Palmfit.Domain.Entities.Common;
using Palmfit.Domain.Entities.Meals;

namespace Palmfit.Domain.Entities.Foods
{
    public class Food : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string Origin { get; set; }
        public string Image { get; set; }
        public decimal Calorie { get; set; }
        public string Unit { get; set; }
        public string FoodClassId { get; set; }
        public FoodClass FoodClass { get; set; }
        public ICollection<MealPlan> MealPlans { get; set; }
    }
}
