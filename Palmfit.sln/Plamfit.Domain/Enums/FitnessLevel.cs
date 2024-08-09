

using System.ComponentModel;

namespace Plamfit.Domain.Enums
{
    public enum FitnessLevel
    {
        [Description("Beginner")]
        Beginner = 1,

        [Description("Intermediate")]
        Intermediate = 2,

        [Description("Advanced")]
        Advanced = 3,

        [Description("Expert")]
        Expert = 4
    }
}
