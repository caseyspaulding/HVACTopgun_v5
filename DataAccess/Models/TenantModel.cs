using DataAccess.Enums;

namespace DataAccess.Models
{
    internal class TenantModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Domain { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdatedAt { get; set; }

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public int ZipCode { get; set; }

        public string Country { get; set; } = string.Empty;

        public string TimeZone { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public SubscriptionType SubscriptionType { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

    }
}
