using Vida.Domain.Common;

namespace Vida.Domain.Entities.EventEntities
{
    public class Event : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateOnly EventDate { get; set; }
        public TimeOnly EventTime { get; set; }
        public string Location { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string OrganizerEmail { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public bool IsActive { get; set; }


    }
    
}
