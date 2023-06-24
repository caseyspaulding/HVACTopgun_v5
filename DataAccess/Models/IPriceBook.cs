namespace DataAccess.Models
{
    public interface IPriceBook
    {
        DateTime CreatedDate { get; set; }
        bool IsDeleted { get; set; }
        bool IsDiscountable { get; set; }
        bool IsFlatRate { get; set; }
        bool IsOptional { get; set; }
        bool IsTaxable { get; set; }
        string? ItemDescription { get; set; }
        string? ItemName { get; set; }
        decimal ItemPrice { get; set; }
        int JobTypeId { get; set; }
        DateTime? ModifiedDate { get; set; }
        int PriceBookId { get; set; }
        int TenantId { get; set; }
    }
}