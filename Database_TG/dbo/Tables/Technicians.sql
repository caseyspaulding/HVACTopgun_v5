CREATE TABLE [dbo].[Technicians]
(
    [TechnicianId] INT NOT NULL PRIMARY KEY IDENTITY,
    [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]),
    [FirstName] NVARCHAR(100) NOT NULL,
    [LastName] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [PhoneNumber] NVARCHAR(100) NOT NULL,
    [Skills] NVARCHAR(MAX) NOT NULL,
    [Availability] NVARCHAR(MAX) NULL
)