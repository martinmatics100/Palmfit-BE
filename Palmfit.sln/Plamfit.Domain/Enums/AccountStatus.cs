

using System.ComponentModel;

namespace Plamfit.Domain.Enums
{
    public enum AccountStatus
    {
        [Description("Active")]
        Active = 1,

        [Description("Inactive")]
        Inactive = 2,

        [Description("Suspended")]
        Suspended = 3,

        [Description("Deactivated")]
        Deactivated = 4
    }
}
