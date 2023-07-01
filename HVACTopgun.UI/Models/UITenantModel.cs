using DataAccess.Enums;

namespace HVACTopGun.UI.Models
{
    public class UITenantModel
    {

        public string TenantId { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;

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
