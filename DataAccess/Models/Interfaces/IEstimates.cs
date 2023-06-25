namespace DataAccess.Models.Interfaces
{
    public interface IEstimates
    {
        int CustomerId { get; set; }
        string? CustomerName { get; set; }
        DateTime Date { get; set; }
        string? Description { get; set; }
        int EstimatesId { get; set; }
        int HVACCompanyId { get; set; }
        int JobTypeId { get; set; }
        string? JobTypeName { get; set; }
        string? Notes { get; set; }
        int Pricing { get; set; }
        int ServiceId { get; set; }
        string? ServiceName { get; set; }
        string? Status { get; set; }
        int TenantId { get; set; }
    }
}