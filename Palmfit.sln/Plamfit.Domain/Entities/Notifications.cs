

namespace Plamfit.Domain.Entities
{
    public class Notifications : BaseEntity
    {
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        public string Url { get; set; }
        public string Message { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
