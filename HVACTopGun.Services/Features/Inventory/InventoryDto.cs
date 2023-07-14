namespace HVACTopGun.Domain.Features.Inventory
{
    public class InventoryDto
    {
        public int InventoryId { get; set; }
        public int TenantID { get; set; }
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
        public bool Deleted { get; set; } = false;
        public DateTime DateDeleted { get; set; }

    }
}
