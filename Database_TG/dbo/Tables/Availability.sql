﻿CREATE TABLE [dbo].[Availability]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]),
    [DayOfWeek] INT NOT NULL,
    [StartTime] TIME NOT NULL,
    [EndTime] TIME NOT NULL,
    [IsAvailable] BIT NOT NULL
    CONSTRAINT FK_Availability_TenantID FOREIGN KEY (TenantID) REFERENCES Tenants(TenantID)
)