﻿CREATE TABLE [dbo].[AvailableAppointmentModel]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
     [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]),
    [Reserved] BIT NOT NULL,
    [StartDate] DATE NOT NULL,
    [StartTime] TIME NOT NULL,
    [EndDate] DATE NOT NULL,
    [EndTime] TIME NOT NULL,
    [CreatedAt] DATETIME NOT NULL,
    [UpdatedAt] DATETIME NOT NULL,
    CONSTRAINT FK_AvailableAppointmentModel_TenantID FOREIGN KEY (TenantID) REFERENCES Tenants(TenantID)
    
)