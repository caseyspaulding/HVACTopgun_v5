CREATE TABLE [dbo].[Customers]
(
	[CustomerID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]), 
    [FirstName] NCHAR(50) NULL, 
    [LastName] NCHAR(50) NULL, 
    [Email] NCHAR(50) NULL, 
   
    [CreatedDateTime] DATETIME2 NOT NULL DEFAULT GETDATE(), 
    [LastUpdated] DATETIME2 NULL DEFAULT GETDATE(), 
    
    [PhoneNumber] NVARCHAR(20) NULL, 
    [Address] NVARCHAR(100) NULL, 
    [City] NVARCHAR(50) NULL, 
    [State] NVARCHAR(20) NULL, 
    [Zipcode] NVARCHAR(20) NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    [Deleted] BIT NULL DEFAULT 0, 
    [SubscriptionType] INT NULL, 
    [PaymentStatus] INT NULL,
    CONSTRAINT FK_Customers_TenantID FOREIGN KEY (TenantID) REFERENCES Tenants(TenantID)

)
