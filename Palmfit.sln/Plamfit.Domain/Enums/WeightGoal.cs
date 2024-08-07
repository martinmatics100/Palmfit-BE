using System.ComponentModel;

namespace Plamfit.Domain.Enums
{
    public enum WeightGoal
    {
        [Description("Lose Weight")]
        LoseWeight,

        [Description("Maintain Weight")]
        MaintainWeight,

        [Description("Gain Weight")]
        GainWeight
    }
}
