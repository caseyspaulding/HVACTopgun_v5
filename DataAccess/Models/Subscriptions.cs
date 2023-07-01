

namespace DataAccess.Models
{
    public class Subscriptions
    {
        public int SubscriptionId { get; set; }
        public int TenantID { get; set; }
        public int CustomerId { get; set; }
        public string? Pricing { get; set; }
        public string? Features { get; set; }
        public string? Status { get; set; }

        public string? CustomerEmail { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerCity { get; set; }
        public string? CustomerState { get; set; }
        public string? CustomerZipCode { get; set; }
        public string? CustomerFirstName { get; set; }
        public string? CustomerLastName { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime DateDeleted { get; set; }



    }
}
