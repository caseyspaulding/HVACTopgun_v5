CREATE TABLE [dbo].[CustomerHistory]
(
    [CustomerHistoryId] INT NOT NULL PRIMARY KEY IDENTITY,
    [CustomerId] INT NOT NULL,
    [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]),
    [JobTypeId] INT NOT NULL,
    [Notes] NVARCHAR(MAX) NULL,
    [Deleted] BIT NOT NULL DEFAULT 0, 
    [DateDeleted] DATETIME2 NULL , 
    CONSTRAINT FK_CustomerHistory_TenantID FOREIGN KEY (TenantID) REFERENCES Tenants(TenantID)
)
