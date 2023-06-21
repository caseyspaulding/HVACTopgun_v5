namespace DataAccess.Models
{
    public interface ICustomerModel
    {
        public int TenantId { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string FirstName { get; set; }
        int Id { get; set; }
        string LastName { get; set; }
        string State { get; set; }
        string ZipCode { get; set; }
    }
}