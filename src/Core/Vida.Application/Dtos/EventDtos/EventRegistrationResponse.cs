using System;

namespace Vida.Application.Dtos.EventDtos;

public class EventRegistrationResponse
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public string EventTitle { get; set; } = string.Empty;
    public string AppUserId { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int NumberOfPeople { get; set; }
    public string Notes { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }
    public bool HasAttended { get; set; }
}