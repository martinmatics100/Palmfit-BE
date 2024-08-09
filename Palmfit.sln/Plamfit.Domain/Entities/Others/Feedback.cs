using Plamfit.Domain.Enums;
using Plamfit.Domain.Entities.Common;

namespace Plamfit.Domain.Entities.Others
{
    public class Feedback : BaseEntity
    {
        public Guid UserId { get; set; }
        public FeedbackType FeedbackType { get; set; }
        public string FeedbackText { get; set; }
        public int Rating { get; set; }
        public string Status { get; set; }
        public string? ResponseText { get; set; }
        public DateTime? RespondedAt { get; set; }
    }
}
