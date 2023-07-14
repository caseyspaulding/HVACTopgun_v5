using HVACTopGun.Domain.Features.Payments;

namespace HVACTopGun.Domain.Features.Customers
{
    public class CustomerBillingModel
    {
        public int BillingId { get; set; }
        public int TenantID { get; set; }
        public int CustomerId { get; set; }
        public string? BillingAddress { get; set; }
        public string? BillingCity { get; set; }
        public string? BillingState { get; set; }
        public string? BillingZipCode { get; set; }
        public string? BillingFirstName { get; set; }
        public string? BillingLastName { get; set; }
        public string? BillingEmail { get; set; }
        public PaymentMethodModel PaymentMethod { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime DateDeleted { get; set; }
    }
}
