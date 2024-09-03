

using Palmfit.Domain.Enums;

namespace Palmfit.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IsDeprecationStatus IsDeprecated { get; set; } = IsDeprecationStatus.False;
    }
}
