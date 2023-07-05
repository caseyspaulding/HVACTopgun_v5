CREATE TABLE [dbo].[AvailableAppointmentModel]
(
    [AvailableAppointmentId] INT NOT NULL PRIMARY KEY IDENTITY,
     [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]),
    [Reserved] BIT NOT NULL,
    [StartDate] DATE NOT NULL,
    [StartTime] TIME NOT NULL,
    [EndDate] DATE NOT NULL,
    [EndTime] TIME NOT NULL,
    [CreatedAt] DATETIME NOT NULL,
    [UpdatedAt] DATETIME NOT NULL,
    [Deleted] BIT NOT NULL DEFAULT 0, 
    [DateDeleted] DATETIME2 NULL , 
    CONSTRAINT FK_AvailableAppointmentModel_TenantID FOREIGN KEY (TenantID) REFERENCES Tenants(TenantID)
    
)