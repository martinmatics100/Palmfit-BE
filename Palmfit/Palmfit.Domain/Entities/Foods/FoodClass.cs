

using Palmfit.Domain.Entities.Common;

namespace Palmfit.Domain.Entities.Foods
{
    public class FoodClass : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public ICollection<Food> Foods { get; set; }
    }
}
