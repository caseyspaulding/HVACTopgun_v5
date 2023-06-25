using DataAccess.Models.Interfaces;

namespace DataAccess.Models;

public class CustomerModel : ICustomerModel
{
    public int Id { get; set; }
    public int TenantId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public List<AppointmentModel> Appointments { get; set; } = new List<AppointmentModel>();
}