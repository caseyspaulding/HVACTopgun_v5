CREATE TABLE [dbo].[Tenants]
(
	[TenantID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [CompanyName] NVARCHAR(50) NULL, 
    [Domain] NVARCHAR(50) NULL, 
    [CreatedDateTime] DATETIME2 NOT NULL DEFAULT GETDATE(), 
    [LastUpdated] DATETIME2 NULL DEFAULT GETDATE(), 
    [Email] NVARCHAR(100) NULL, 
    [PhoneNumber] NVARCHAR(20) NULL, 
    [Address] NVARCHAR(100) NULL, 
    [City] NVARCHAR(50) NULL, 
    [State] NVARCHAR(20) NULL, 
    [Zipcode] NVARCHAR(20) NULL, 
    
    [TimeZone] NVARCHAR(50) NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    
    [SubscriptionType] INT NULL, 
    [PaymentStatus] INT NULL,
    [Deleted] BIT NOT NULL DEFAULT 0, 
    [DateDeleted] DATETIME2 NULL , 
    
)