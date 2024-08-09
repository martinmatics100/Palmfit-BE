

using System.ComponentModel;

namespace Plamfit.Domain.Enums
{
    public static class HealthEnums
    {
        public enum GenoType
        {
            [Description("AA Genotype")]
            AA = 1,

            [Description("AS Genotype")]
            AS = 2,

            [Description("SS Genotype")]
            SS = 3,

            [Description("SC Genotype")]
            SC = 4
        }

        public enum BloodGroup
        {
            [Description("Blood Group A")]
            A = 1,

            [Description("Blood Group B")]
            B = 2,

            [Description("Blood Group AB")]
            AB = 3,

            [Description("Blood Group O")]
            O = 4,
        }
    }
}
