CREATE TABLE [dbo].[Technicians]
(
    [TechnicianId] INT NOT NULL PRIMARY KEY IDENTITY,
    [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]),
    [FirstName] NVARCHAR(100) NOT NULL,
    [LastName] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [PhoneNumber] NVARCHAR(100) NOT NULL,
    [Skills] NVARCHAR(MAX) NOT NULL,
    [Availability] NVARCHAR(MAX) NULL,
    [Deleted] BIT NOT NULL DEFAULT 0, 
    [DateDeleted] DATETIME2 NULL , 
    CONSTRAINT FK_Technicians_TenantID FOREIGN KEY (TenantID) REFERENCES Tenants(TenantID)
)