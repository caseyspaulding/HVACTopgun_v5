

namespace DataAccess.Models;

public class CustomerModel
{
    public int Id { get; set; }
    public int TenantID { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public bool Deleted { get; set; } = false;
    public DateTime DateDeleted { get; set; }
    public List<AppointmentModel> Appointments { get; set; } = new List<AppointmentModel>();
}