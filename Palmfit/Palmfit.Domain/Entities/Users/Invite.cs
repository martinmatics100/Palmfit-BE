

using Palmfit.Domain.Entities.Common;

namespace Palmfit.Domain.Entities.Users
{
    public class Invite : BaseEntity
    {
        public DateTime InviteDate { get; set; }
        public string Name { get; set; }
        public string InviteeEmail { get; set; }
        public string Phone { get; set; }
        public bool IsAccepted { get; set; }
        public Guid InviterId { get; set; }
        public AppUser Inviter { get; set; }
    }
}
