

using System.ComponentModel;

namespace Plamfit.Domain.Enums
{
    public enum AccountStatus
    {
        [Description("Active")]
        Active,

        [Description("Inactive")]
        Inactive,

        [Description("Suspended")]
        Suspended,

        [Description("Deactivated")]
        Deactivated
    }
}
