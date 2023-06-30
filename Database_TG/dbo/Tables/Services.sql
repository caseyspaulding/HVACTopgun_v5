CREATE TABLE [dbo].[Services]
(
	[ServiceID] INT NOT NULL PRIMARY KEY, 
    [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]), 
    [Name] NCHAR(10) NULL, 
    [Description] NVARCHAR(100) NULL, 
    [Duration] NCHAR(10) NULL, 
    [Pricing] DECIMAL NULL
)
