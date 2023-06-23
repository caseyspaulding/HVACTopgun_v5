namespace DataAccess.Models
{
    public interface ICustomerModel
    {
        string Address { get; set; }
        List<AppointmentModel> Appointments { get; set; }
        string City { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        int Id { get; set; }
        string LastName { get; set; }
        string Phone { get; set; }
        string State { get; set; }
        int TenantId { get; set; }
        string ZipCode { get; set; }
    }
}