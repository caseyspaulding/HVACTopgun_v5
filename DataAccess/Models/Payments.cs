using DataAccess.Enums;
using DataAccess.Models.Interfaces;

namespace DataAccess.Models
{
    public class Payments : IPayments
    {
        public int PaymentId { get; set; } // primary key
        public int TenantId { get; set; } // foreign key referencing tenants table
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
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
