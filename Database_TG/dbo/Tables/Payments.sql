CREATE TABLE [dbo].[Payments]
(
    [PaymentId] INT NOT NULL PRIMARY KEY,
       [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]),
    [CustomerId] INT NOT NULL,
    [JobTypeId] INT NOT NULL,
    [HVACCompanyId] INT NOT NULL,
    [ServiceId] INT NOT NULL,
    [Date] DATETIME NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    [Notes] NVARCHAR(MAX) NULL,
    [Status] NVARCHAR(50) NULL,
    [ServiceName] NVARCHAR(50) NULL,
    [JobTypeName] NVARCHAR(50) NULL,
    [CustomerName] NVARCHAR(50) NULL,
    [Amount] FLOAT NOT NULL,
    [PaymentStatus] NVARCHAR(50) NULL,
    [PaymentMethod] NVARCHAR(50) NULL,
    [Deleted] BIT NOT NULL DEFAULT 0, 
    [DateDeleted] DATETIME2 NULL , 
    CONSTRAINT FK_Payments_TenantID FOREIGN KEY (TenantID) REFERENCES Tenants(TenantID)
)