using DataAccess.Enums;
using DataAccess.Models.Interfaces;

namespace DataAccess.Models
{
    public class TenantModel : ITenantModel
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Domain { get; set; } = string.Empty;

        public DateTime CreatedDateTime { get; set; }

        public DateTime LastUpdated { get; set; }

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string? ZipCode { get; set; }

        public string Country { get; set; } = string.Empty;

        public string TimeZone { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public bool Deleted { get; set; }

        public SubscriptionType SubscriptionType { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
    }
}