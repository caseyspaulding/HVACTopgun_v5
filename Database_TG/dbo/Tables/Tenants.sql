CREATE TABLE [dbo].[Tenants]
(
	[TenantId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [CompanyName] NVARCHAR(50) NULL, 
    [Domain] NVARCHAR(50) NULL, 
    [CreatedDateTime] DATETIME2 NULL, 
    [LastUpdated] DATETIME2 NULL, 
    [Email] NVARCHAR(50) NULL, 
    [PhoneNumber] NVARCHAR(50) NULL, 
    [Address] NVARCHAR(50) NULL, 
    [City] NVARCHAR(50) NULL, 
    [State] NCHAR(10) NULL, 
    [Zipcode] INT NULL, 
    [Country] NCHAR(10) NULL, 
    [TimeZone] NCHAR(10) NULL, 
    [IsActive] BIT NULL, 
    [Deleted] BIT NULL, 
    [SubscriptionType] INT NULL, 
    [PaymentStatus] INT NULL
)
