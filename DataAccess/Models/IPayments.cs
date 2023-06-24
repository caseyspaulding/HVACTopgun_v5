using DataAccess.Enums;

namespace DataAccess.Models
{
    public interface IPayments
    {
        double Amount { get; set; }
        int CustomerId { get; set; }
        string? CustomerName { get; set; }
        DateTime Date { get; set; }
        string? Description { get; set; }
        int HVACCompanyId { get; set; }
        int JobTypeId { get; set; }
        string? JobTypeName { get; set; }
        string? Notes { get; set; }
        int PaymentId { get; set; }
        PaymentMethod PaymentMethod { get; set; }
        PaymentStatus PaymentStatus { get; set; }
        int ServiceId { get; set; }
        string? ServiceName { get; set; }
        string? Status { get; set; }
        int TenantId { get; set; }
    }
}