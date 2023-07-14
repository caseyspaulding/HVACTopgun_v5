namespace HVACTopGun.Domain.Features.Invoices
{
    internal class InvoicesDto
    {
        public int InvoiceId { get; set; }
        public int TenantID { get; set; }
        public int CustomerId { get; set; }
        public int JobTypeId { get; set; }
        public int HVACCompanyId { get; set; }
        public int ServiceId { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public string? Status { get; set; }
        public string? ServiceName { get; set; }
        public string? JobTypeName { get; set; }
        public string? CustomerName { get; set; }
        public double Pricing { get; set; }
        public double Taxes { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime DateDeleted { get; set; }
    }
}
