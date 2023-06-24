namespace DataAccess.Models
{
    public class PriceBook : IPriceBook
    {
        public int PriceBookId { get; set; }
        public int TenantId { get; set; }
        public int JobTypeId { get; set; }
        public string? ItemName { get; set; }
        public string? ItemDescription { get; set; }
        public decimal ItemPrice { get; set; }
        public bool IsFlatRate { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsDiscountable { get; set; }
        public bool IsOptional { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
