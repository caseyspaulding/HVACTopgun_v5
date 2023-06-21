namespace DataAccess.Models
{
    public class TechnicianModel
    {

        public int Id { get; set; }
        public int TenantId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Skills { get; set; } = string.Empty;
        public AvailabilityModel? Availability { get; set; }
        public List<AppointmentModel> Appointments { get; set; } = new List<AppointmentModel>();
    }

}
