namespace HVACTopGun.Domain.Features.Availability
{
    public class AvailableAppointmentDto
    {
        public int AvailableAppointmentId { get; set; }

        public int TenantID { get; set; }

        public bool Reserved { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime DateDeleted { get; set; }
    }
}