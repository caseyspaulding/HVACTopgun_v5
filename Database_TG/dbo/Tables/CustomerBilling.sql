CREATE TABLE [dbo].[CustomerBilling]
(
    [BillingId] INT NOT NULL PRIMARY KEY IDENTITY,
   [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]),
    [CustomerId] INT NOT NULL,
    [BillingAddress] NVARCHAR(100) NULL,
    [BillingCity] NVARCHAR(50) NULL,
    [BillingState] NVARCHAR(50) NULL,
    [BillingZipCode] NVARCHAR(10) NULL,
    [BillingFirstName] NVARCHAR(50) NULL,
    [BillingLastName] NVARCHAR(50) NULL,
    [BillingEmail] NVARCHAR(100) NULL,
    [PaymentMethod] NVARCHAR(50) NULL,
    CONSTRAINT FK_CustomerBilling_TenantID FOREIGN KEY (TenantID) REFERENCES Tenants(TenantID)
)
