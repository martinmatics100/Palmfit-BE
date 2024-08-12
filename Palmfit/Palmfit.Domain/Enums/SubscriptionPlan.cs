

using System.ComponentModel;

namespace Palmfit.Domain.Enums
{
    public enum SubscriptionPlan
    {
        [Description("Free")]
        Free = 1,

        [Description("Basic")]
        Basic = 2,

        [Description("Premium")]
        Premium1 = 3,

        [Description("Very Important Person")]
        VIP = 4
    }
}
