

using System.ComponentModel;

namespace Palmfit.Domain.Enums
{
    public enum WeightGoal
    {
        [Description("Lose Weight")]
        LoseWeight = 1,

        [Description("Maintain Weight")]
        MaintainWeight = 2,

        [Description("Gain Weight")]
        GainWeight = 3
    }
}
