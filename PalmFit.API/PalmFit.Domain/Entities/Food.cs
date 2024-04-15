using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalmFit.Domain.Entities
{
    public class Food : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string Origin { get; set; }
        public decimal Calorie { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Protein { get; set; }
        public string Fats { get; set; }
        public string FoodClassId { get; set; }
        public FoodClass FoodClass { get; set; }
    }
}
