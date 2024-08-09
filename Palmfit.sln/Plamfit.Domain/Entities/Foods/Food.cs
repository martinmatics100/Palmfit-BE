using Plamfit.Domain.Entities.Common;

namespace Plamfit.Domain.Entities.Foods
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
    }
}
