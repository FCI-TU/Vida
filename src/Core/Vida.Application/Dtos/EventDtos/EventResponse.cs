using System;

namespace Vida.Application.Dtos.EventDtos;

public class EventResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime EventDate { get; set; }
    public TimeSpan EventTime { get; set; }
    public int Capacity { get; set; }
    public string OrganizerEmail { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public string Category { get; set; } = string.Empty;
    public int AvailableSpots { get; set; }
    public int TotalRegistrations { get; set; }
}
