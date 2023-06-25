namespace DataAccess.Models.Interfaces
{
    public interface IInventory
    {
        int InventoryId { get; set; }
        string? ItemBrand { get; set; }
        string? ItemCategory { get; set; }
        string? ItemColor { get; set; }
        string? ItemDescription { get; set; }
        string? ItemImage { get; set; }
        string? ItemModel { get; set; }
        string? ItemName { get; set; }
        decimal ItemPrice { get; set; }
        int ItemQuantity { get; set; }
        string? ItemSerialNumber { get; set; }
        string? ItemSubCategory { get; set; }
        int TenantId { get; set; }
    }
}