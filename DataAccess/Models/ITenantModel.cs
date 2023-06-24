using DataAccess.Enums;

namespace DataAccess.Models
{
    public interface ITenantModel
    {
        string Address { get; set; }
        string City { get; set; }
        string Country { get; set; }
        DateTime CreatedDateTime { get; set; }
        bool Deleted { get; set; }
        string Domain { get; set; }
        string Email { get; set; }
        int Id { get; set; }
        bool IsActive { get; set; }
        DateTime LastUpdated { get; set; }
        string Name { get; set; }
        PaymentStatus PaymentStatus { get; set; }
        string PhoneNumber { get; set; }
        string State { get; set; }
        SubscriptionType SubscriptionType { get; set; }
        string TimeZone { get; set; }
        string? ZipCode { get; set; }
    }
}