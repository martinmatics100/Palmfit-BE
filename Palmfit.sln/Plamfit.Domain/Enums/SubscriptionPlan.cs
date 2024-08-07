

using System.ComponentModel;

namespace Plamfit.Domain.Enums
{
    public enum SubscriptionPlan
    {
        [Description("Free")]
        Free,

        [Description("Basic")]
        Basic,

        [Description("Premium")]
        Premium,

        [Description("Very Important Person")]
        VIP
    }
}
