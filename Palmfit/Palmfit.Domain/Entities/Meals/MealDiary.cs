

using Palmfit.Domain.Entities.Common;

namespace Palmfit.Domain.Entities.Meals
{
    public class MealDiary : BaseEntity
    {
        public Guid UserId { get; set; } 
        public DateTime Date { get; set; }
        public ICollection<LoggedMeal> Meals { get; set; }

        public MealDiary()
        {
            Meals = new List<LoggedMeal>();
        }
    }
}
