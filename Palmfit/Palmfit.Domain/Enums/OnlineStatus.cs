

using System.ComponentModel;

namespace Palmfit.Domain.Enums
{
    public enum OnlineStatus
    {
        [Description("Online")]
        Offline = 1,

        [Description("Offline")]
        Online = 2
    }
}
