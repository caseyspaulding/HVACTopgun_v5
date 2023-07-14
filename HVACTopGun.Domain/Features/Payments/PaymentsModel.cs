namespace HVACTopGun.Domain.Features.Payments
{
    public class PaymentsModel
    {
        public int PaymentId { get; set; } // primary key
        public int TenantID { get; set; } // foreign key referencing tenants table
        public int CustomerId { get; set; } // foreign key referencing customers table
        public int JobTypeId { get; set; } // foreign key referencing jobtypes table
        public int HVACCompanyId { get; set; } // foreign key referencing hvaccompanies table
        public int ServiceId { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public string? Status { get; set; }
        public string? ServiceName { get; set; }
        public string? JobTypeName { get; set; }
        public string? CustomerName { get; set; }
        public double Amount { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime DateDeleted { get; set; }
        public PaymentStatusModel PaymentStatus { get; set; }
        public PaymentMethodModel PaymentMethod { get; set; }
    }
}
