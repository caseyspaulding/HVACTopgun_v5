namespace DataAccess.Models
{
    public interface ITechnicianModel
    {
        List<AppointmentModel> Appointments { get; set; }
        AvailabilityModel? Availability { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        int Id { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string Skills { get; set; }
        int TenantId { get; set; }
    }
}