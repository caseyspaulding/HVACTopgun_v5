using DataAccess.Models.Interfaces;

namespace DataAccess.Models
{
    public class Inventory : IInventory
    {
        public int InventoryId { get; set; }
        public int TenantId { get; set; }
        public string? ItemName { get; set; }
        public string? ItemDescription { get; set; }
        public int ItemQuantity { get; set; }
        public decimal ItemPrice { get; set; }
        public string? ItemImage { get; set; }
        public string? ItemCategory { get; set; }
        public string? ItemSubCategory { get; set; }
        public string? ItemBrand { get; set; }
        public string? ItemModel { get; set; }
        public string? ItemSerialNumber { get; set; }
        public string? ItemColor { get; set; }

    }
}
