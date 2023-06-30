CREATE TABLE [dbo].[Users]
(
	[UserId] INT NOT NULL PRIMARY KEY  IDENTITY, 
    [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]), 
    [AzureAD_ObjectID] NVARCHAR(50) NULL, 
    [Role] NVARCHAR(50) NULL, 
    [UserName] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(100) NULL, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [PhoneNumber] NVARCHAR(20) NULL
)