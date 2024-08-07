

using Plamfit.Domain.Enums.Units;
using static Plamfit.Domain.Enums.HealthEnums;

namespace Plamfit.Domain.Entities
{
    public class Health : BaseEntity
    {
        public double Height { get; set; }
        public HeightUnit HeightUnit { get; set; }
        public double Weight { get; set; }
        public WeightUnit WeightUnit { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public GenoType GenoType { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}