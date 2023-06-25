namespace DataAccess.Models.Interfaces
{
    public interface ICustomerHistory
    {
        int CustomerHistoryId { get; set; }
        int CustomerId { get; set; }
        int JobTypeId { get; set; }
        string? Notes { get; set; }
        int TenantId { get; set; }
    }
}