using Vida.Domain.Common;
using Vida.Domain.Entities.IdentityEntities;

namespace Vida.Domain.Entities.EventEntities
{
    public class EventRegistration : BaseEntity
    {
        public int EventId { get; set; }
        public int AppUserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int NumberOfPeople { get; set; }
        public string Notes { get; set; } = string.Empty;
        public bool HasAttended { get; set; }
        public DateTime RegistrationDate { get; set; }
        
        // Navigation properties
        public Event Event { get; set; } = null!;
        public AppUser AppUser { get; set; } = null!;
    }
    
}
