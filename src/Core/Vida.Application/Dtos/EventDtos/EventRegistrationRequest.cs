using System;

namespace Vida.Application.Dtos.EventDtos;

public class EventRegistrationRequest
{
    public int EventId { get; set; }
    public string AppUserId { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int NumberOfPeople { get; set; } = 1;
    public string Notes { get; set; } = string.Empty;
}