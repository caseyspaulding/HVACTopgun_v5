namespace DataAccess.Models.Interfaces
{
    internal interface IInvoices
    {
        int CustomerId { get; set; }
        string? CustomerName { get; set; }
        DateTime Date { get; set; }
        string? Description { get; set; }
        int HVACCompanyId { get; set; }
        int InvoiceId { get; set; }
        int JobTypeId { get; set; }
        string? JobTypeName { get; set; }
        string? Notes { get; set; }
        double Pricing { get; set; }
        int ServiceId { get; set; }
        string? ServiceName { get; set; }
        string? Status { get; set; }
        double Taxes { get; set; }
        int TenantId { get; set; }
    }
}