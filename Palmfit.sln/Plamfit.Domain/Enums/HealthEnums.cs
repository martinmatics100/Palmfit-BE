

using System.ComponentModel;

namespace Plamfit.Domain.Enums
{
    public static class HealthEnums
    {
        public enum GenoType
        {
            [Description("AA Genotype")]
            AA,

            [Description("AS Genotype")]
            AS,

            [Description("SS Genotype")]
            SS,

            [Description("SC Genotype")]
            SC
        }

        public enum BloodGroup
        {
            [Description("Blood Group A")]
            A,

            [Description("Blood Group B")]
            B,

            [Description("Blood Group AB")]
            AB,

            [Description("Blood Group O")]
            O
        }
    }
}
