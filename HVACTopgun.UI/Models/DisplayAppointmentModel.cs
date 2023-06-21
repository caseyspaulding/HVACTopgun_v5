﻿namespace HVACTopGun.UI.Models
{
    public class DisplayAppointmentModel
    {
        public int Id { get; set; }

        public int TenantId { get; set; }

        public int AvailableAppointmentId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }



    }

}

