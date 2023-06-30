CREATE TABLE [dbo].[PriceBook]
(
    [PriceBookId] INT NOT NULL PRIMARY KEY,
    [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]),
    [JobTypeId] INT NOT NULL,
    [ItemName] NVARCHAR(100) NULL,
    [ItemDescription] NVARCHAR(MAX) NULL,
    [ItemPrice] DECIMAL(18, 2) NOT NULL,
    [IsFlatRate] BIT NOT NULL,
    [IsTaxable] BIT NOT NULL,
    [IsDiscountable] BIT NOT NULL,
    [IsOptional] BIT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    [CreatedDate] DATETIME NOT NULL,
    [ModifiedDate] DATETIME NULL
)
