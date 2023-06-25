using DataAccess.Enums;
using DataAccess.Models;
using DataAccess.Models.Interfaces;

namespace HVACTopGun.UI.Models
{
    public class UIAppointmentModel : IAppointmentModel
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
        public int AppointmentId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CategoryColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CssClass { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public CustomerModel Customer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int CustomerId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CustomerName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string EndTimeZone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsAllDay { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsBlock { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsReadonly { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public JobTypeModel JobType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int JobTypeId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Location { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string RecurrenceException { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int? RecurrenceID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string RecurrenceRule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ServiceId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string StartTimeZone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public JobStatus Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Subject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TechnicianModel Technician { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int TechnicianId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string TechnicianName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string TenantName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}