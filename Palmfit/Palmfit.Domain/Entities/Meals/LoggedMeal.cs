using Palmfit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Domain.Entities.Meals
{
    public class LoggedMeal : BaseEntity
    {
        public string MealType { get; set; }
        public Guid FoodId { get; set; }
        public double PortionSize { get; set; }
        public DateTime LoggedAt { get; set; }
    }
}
