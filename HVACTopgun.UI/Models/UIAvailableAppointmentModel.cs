namespace HVACTopGun.UI.Models
{
    public class UIAvailableAppointmentModel
    {
        public int Id { get; set; }

        public bool Reserved { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}