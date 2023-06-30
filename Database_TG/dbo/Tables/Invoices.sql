CREATE TABLE [dbo].[Invoices]
(
    [InvoiceId] INT NOT NULL PRIMARY KEY IDENTITY,
    [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]),
    [CustomerId] INT NOT NULL,
    [JobTypeId] INT NOT NULL,
    [HVACCompanyId] INT NOT NULL,
    [ServiceId] INT NOT NULL,
    [Date] DATETIME NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    [Notes] NVARCHAR(MAX) NULL,
    [Status] NVARCHAR(50) NULL,
    [ServiceName] NVARCHAR(100) NULL,
    [JobTypeName] NVARCHAR(100) NULL,
    [CustomerName] NVARCHAR(100) NULL,
    [Pricing] FLOAT NOT NULL,
    [Taxes] FLOAT NOT NULL
)

