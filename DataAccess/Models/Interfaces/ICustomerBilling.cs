using DataAccess.Enums;

namespace DataAccess.Models.Interfaces
{
    public interface ICustomerBilling
    {
        string? BillingAddress { get; set; }
        string? BillingCity { get; set; }
        string? BillingEmail { get; set; }
        string? BillingFirstName { get; set; }
        int BillingId { get; set; }
        string? BillingLastName { get; set; }
        string? BillingState { get; set; }
        string? BillingZipCode { get; set; }
        int CustomerId { get; set; }
        PaymentMethod PaymentMethod { get; set; }
        int TenantId { get; set; }
    }
}