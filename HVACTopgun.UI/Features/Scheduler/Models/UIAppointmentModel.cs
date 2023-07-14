using HVACTopGun.Domain.Features.Appointments;
using HVACTopGun.Domain.Features.Customers;
using HVACTopGun.Domain.Features.Technicians;

namespace HVACTopGun.UI.Features.Scheduler.Models
{
    public class UIAppointmentModel
    {
        public int Id { get; set; }
        public int TenantID { get; set; }
        public int UserId { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? TechnicianName { get; set; }
        public string? CustomerName { get; set; }
        public string? Location { get; set; }
        public JobStatusEnum Status { get; set; }
        public bool IsAllDay { get; set; }
        public int? RecurrenceId { get; set; }
        public string? RecurrenceRule { get; set; }
        public string? RecurrenceException { get; set; }
        public bool IsReadonly { get; set; }
        public bool IsBlock { get; set; }
        public string? CssClass { get; set; }
        public int AvailableAppointmentId { get; set; }
        public string TenantName { get; set; } = string.Empty;
        public string? CategoryColor { get; set; }
        public string? StartTimeZone { get; set; }
        public string? EndTimeZone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int TechnicianId { get; set; }  // Foreign key to Technician entity
        public TechnicianModel? Technician { get; set; }  // Navigation property to Technician entity
        public int CustomerId { get; set; }  // Foreign key to Customer entity
        public CustomerModel? Customer { get; set; }   // Navigation property to Customer entity
        public int ServiceId { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime DateDeleted { get; set; }
        public int JobTypeId { get; set; } // Foreign key to JobTypes table
        public JobTypeModel? JobType { get; set; } // Navigation property to JobTypes table

    }
}
