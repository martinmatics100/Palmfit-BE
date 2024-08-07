

using System.ComponentModel;

namespace Plamfit.Domain.Enums
{
    public enum ActivityLevel
    {
        [Description("Inactive")]
        Inactive,

        [Description("Some What Active")]
        SomeWhatActive,

        [Description("Active")]
        Active,
    }
}
