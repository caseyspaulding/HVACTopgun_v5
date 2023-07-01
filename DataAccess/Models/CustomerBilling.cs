using DataAccess.Enums;


namespace DataAccess.Models
{
    public class CustomerBilling
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
        public PaymentMethod PaymentMethod { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime DateDeleted { get; set; }
    }
}
