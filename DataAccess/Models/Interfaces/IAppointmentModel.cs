using DataAccess.Enums;

namespace DataAccess.Models.Interfaces
{
    public interface IAppointmentModel
    {
        int AppointmentId { get; set; }
        int AvailableAppointmentId { get; set; }
        string? CategoryColor { get; set; }
        DateTime CreatedAt { get; set; }
        string? CssClass { get; set; }
        CustomerModel? Customer { get; set; }
        int CustomerId { get; set; }
        string? CustomerName { get; set; }
        string? Description { get; set; }
        DateTime EndTime { get; set; }
        string? EndTimeZone { get; set; }
        bool IsAllDay { get; set; }
        bool IsBlock { get; set; }
        bool IsReadonly { get; set; }
        JobTypeModel? JobType { get; set; }
        int JobTypeId { get; set; }
        string? Location { get; set; }
        string? RecurrenceException { get; set; }
        int? RecurrenceID { get; set; }
        string? RecurrenceRule { get; set; }
        int ServiceId { get; set; }
        DateTime StartTime { get; set; }
        string? StartTimeZone { get; set; }
        JobStatus Status { get; set; }
        string? Subject { get; set; }
        TechnicianModel? Technician { get; set; }
        int TechnicianId { get; set; }
        string? TechnicianName { get; set; }
        int TenantId { get; set; }
        string TenantName { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}