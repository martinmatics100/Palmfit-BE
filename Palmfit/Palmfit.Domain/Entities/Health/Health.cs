

using Palmfit.Domain.Entities.Common;
using Palmfit.Domain.Entities.Users;
using Palmfit.Domain.Enums.Units;
using static Palmfit.Domain.Enums.HealthEnums;

namespace Palmfit.Domain.Entities.Health
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
