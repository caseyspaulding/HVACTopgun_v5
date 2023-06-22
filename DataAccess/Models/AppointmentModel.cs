namespace DataAccess.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public int AvailableAppointmentId { get; set; }
        public int TenantId { get; set; }
        public string? Subject { get; set; }
        public string? Location { get; set; }
        public string TenantName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAllDay { get; set; }
        public string? CategoryColor { get; set; }
        public string? RecurrenceRule { get; set; }
        public int? RecurrenceID { get; set; }
        public string? RecurrenceException { get; set; }
        public string? StartTimeZone { get; set; }
        public string? EndTimeZone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int TechnicianId { get; set; } // Foreign key to Technician entity
        public TechnicianModel? Technician { get; set; } // Navigation property to Technician entity
        public int CustomerId { get; set; } // Foreign key to Customer entity
        public CustomerModel? Customer { get; set; } // Navigation property to Customer entity
    }
}