CREATE TABLE [dbo].[Users]
(
	[UserId] INT NOT NULL PRIMARY KEY  IDENTITY, 
    [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]) NOT NULL, 
    [AzureAD_ObjectID] NVARCHAR(128) NOT NULL, 
    [Role] NVARCHAR(20) NULL, 
    [UserName] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(100) NULL, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [PhoneNumber] NVARCHAR(20) NULL,
    [Deleted] BIT NOT NULL DEFAULT 0, 
    [DateDeleted] DATETIME2 NULL , 
   
    
    CONSTRAINT FK_Users_TenantID FOREIGN KEY (TenantID) REFERENCES Tenants(TenantID)
)