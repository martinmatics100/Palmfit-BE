﻿

using System.ComponentModel;

namespace Palmfit.Domain.Enums
{
    public enum ActivityLevel
    {
        [Description("Inactive")]
        Inactive = 1,

        [Description("Some What Active")]
        SomeWhatActive = 2,

        [Description("Active")]
        Active = 3,
    }
}