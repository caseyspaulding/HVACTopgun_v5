namespace DataAccess.Models.Interfaces
{
    public interface ISubscriptions
    {
        string? CustomerAddress { get; set; }
        string? CustomerCity { get; set; }
        string? CustomerEmail { get; set; }
        string? CustomerFirstName { get; set; }
        int CustomerId { get; set; }
        string? CustomerLastName { get; set; }
        string? CustomerPhone { get; set; }
        string? CustomerState { get; set; }
        string? CustomerZipCode { get; set; }
        string? Features { get; set; }
        string? Pricing { get; set; }
        string? Status { get; set; }
        int SubscriptionId { get; set; }
        int TenantId { get; set; }
    }
}