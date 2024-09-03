

using Palmfit.Domain.Entities.Common;
using Palmfit.Domain.Entities.Users;
using Palmfit.Domain.Enums;

namespace Palmfit.Domain.Entities.Others
{
    public class Feedback : BaseEntity
    {
        public ICollection<AppUser> Users { get; set; }
        public FeedbackType FeedbackType { get; set; }
        public string FeedbackText { get; set; }
        public int Rating { get; set; }
        public string Status { get; set; }
        public string? ResponseText { get; set; }
        public DateTime? RespondedAt { get; set; }
    }
}
