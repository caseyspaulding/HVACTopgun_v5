CREATE TABLE [dbo].[Subscriptions]
(
    [SubscriptionId] INT NOT NULL PRIMARY KEY,
    [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]),
    [CustomerId] INT NOT NULL,
    [Pricing] NVARCHAR(MAX) NULL,
    [Features] NVARCHAR(MAX) NULL,
    [Status] NVARCHAR(50) NULL,
    [CustomerEmail] NVARCHAR(100) NULL,
    [CustomerPhone] NVARCHAR(20) NULL,
    [CustomerAddress] NVARCHAR(100) NULL,
    [CustomerCity] NVARCHAR(50) NULL,
    [CustomerState] NVARCHAR(50) NULL,
    [CustomerZipCode] NVARCHAR(20) NULL,
    [CustomerFirstName] NVARCHAR(50) NULL,
    [CustomerLastName] NVARCHAR(50) NULL
)
