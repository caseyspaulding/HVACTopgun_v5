namespace HVACTopGun.Domain.Features.Appointments;

public class AppointmentModel
{
    public int Id { get; set; }
    public int TenantID { get; set; }
    public int UserId { get; set; }
    public string? Subject { get; set; }
    public string? Description { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string? TechnicianName { get; set; }
    public string? CustomerName { get; set; }
    public string? Location { get; set; }
    public JobStatusEnum? Status { get; set; }
    public bool? IsAllDay { get; set; }
    public int? RecurrenceID { get; set; }
    public string? RecurrenceRule { get; set; }
    public string? RecurrenceException { get; set; }
    public bool? IsReadonly { get; set; }
    public bool? IsBlock { get; set; }
    public string? CssClass { get; set; }
    public int? AvailableAppointmentId { get; set; }
    public string? TenantName { get; set; }
    public string? CategoryColor { get; set; }
    public string? StartTimeZone { get; set; }
    public string? EndTimeZone { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? TechnicianId { get; set; }
    public int? CustomerId { get; set; }
    public int? ServiceId { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? DateDeleted { get; set; }
    public int? JobTypeId { get; set; }
}