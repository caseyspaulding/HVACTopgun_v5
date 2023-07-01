CREATE TABLE [dbo].[Inventory]
(
    [InventoryId] INT NOT NULL PRIMARY KEY IDENTITY,
    [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]),
    [ItemName] NVARCHAR(100) NULL,
    [ItemDescription] NVARCHAR(MAX) NULL,
    [ItemQuantity] INT NOT NULL,
    [ItemPrice] DECIMAL(18, 2) NOT NULL,
    [ItemImage] NVARCHAR(MAX) NULL,
    [ItemCategory] NVARCHAR(100) NULL,
    [ItemSubCategory] NVARCHAR(100) NULL,
    [ItemBrand] NVARCHAR(100) NULL,
    [ItemModel] NVARCHAR(100) NULL,
    [ItemSerialNumber] NVARCHAR(100) NULL,
    [ItemColor] NVARCHAR(100) NULL,
    [Deleted] BIT NOT NULL DEFAULT 0, 
    [DateDeleted] DATETIME2 NULL , 
    
    CONSTRAINT FK_Inventory_TenantID FOREIGN KEY (TenantID) REFERENCES Tenants(TenantID)
)
