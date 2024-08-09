

using System.ComponentModel;

namespace Plamfit.Domain.Enums
{
    public enum FeedbackType
    {
        [Description("Complaint")]
        Complaint = 1,

        [Description("Suggestion")]
        Suggestion = 2,

        [Description("Praise")]
        Praise = 3,

        [Description("Inquiry")]
        Inquiry = 4,

        [Description("Other")]
        Other = 5
    }
}
