

using Palmfit.Domain.Entities.Common;
using Palmfit.Domain.Entities.Foods;

namespace Palmfit.Domain.Entities.Meals
{
    public class Meal : BaseEntity
    {
        public ICollection<MealFood> Breakfast { get; set; }
        public ICollection<MealFood> Lunch { get; set; }
        public ICollection<MealFood> Dinner { get; set; }

    }
}
