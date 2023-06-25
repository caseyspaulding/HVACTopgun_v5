using DataAccess.Models.Interfaces;

namespace DataAccess.Models
{
    public class CustomerHistory : ICustomerHistory
    {
        public int CustomerHistoryId { get; set; }
        public int CustomerId { get; set; }
        public int TenantId { get; set; }
        public int JobTypeId { get; set; }
        public string? Notes { get; set; }
    }
}
