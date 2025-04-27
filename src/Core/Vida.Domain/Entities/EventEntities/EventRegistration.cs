using Vida.Domain.Common;
using Vida.Domain.Entities.IdentityEntities;

namespace Vida.Domain.Entities.EventEntities;

public class EventRegistration : BaseEntity
{
    public int EventId { get; set; }
    public Event Event { get; set; } = null!;
    public string AppUserId { get; set; } = string.Empty;
    public AppUser AppUser { get; set; } = null!;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int NumberOfPeople { get; set; } = 1;
    public string Notes { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    public bool HasAttended { get; set; } = false;
}