CREATE TABLE [dbo].[Appointments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]) NOT NULL, -- If associated with a tenant
    [CustomerId] INT FOREIGN KEY REFERENCES Customers([CustomerId]), -- If associated with a customer
    [ServiceId] INT FOREIGN KEY REFERENCES [Services]([ServiceId]), -- If associated with a service
    [UserId] INT FOREIGN KEY REFERENCES Users([UserId]), -- If associated with a User (like a staff member)
    [Subject] NVARCHAR(100) NULL,
    [Description] NVARCHAR(100) NULL,
    [StartTime] DATETIME2 NULL,
    [EndTime] DATETIME2 NULL,
    [TechnicianName] NVARCHAR(50) NULL,
    [CustomerName] NVARCHAR(100) NULL,
    [Location] NVARCHAR(100) NULL,
    [Status] INT NULL,
    [IsAllDay] BIT NULL,
    [RecurrenceID] INT NULL,
    [RecurrenceRule] NVARCHAR(500) NULL,
    [RecurrenceException] NVARCHAR(500) NULL,
    [IsReadonly] BIT NULL,
    [IsBlock] BIT NULL,
    [CssClass] NVARCHAR(100) NULL,
    [AvailableAppointmentId] INT NULL,
    [TenantName] NVARCHAR(100) NULL,
    [CategoryColor] NVARCHAR(20) NULL,
    [StartTimeZone] NVARCHAR(100) NULL,
    [EndTimeZone] NVARCHAR(100) NULL,
    [CreatedAt] DATETIME2 NULL DEFAULT GETDATE(),
    [UpdatedAt] DATETIME2 NULL DEFAULT GETDATE(),
    [TechnicianId] INT NULL,
    [JobTypeId] INT NULL, 
    [JobStatus] BIT NULL, 
    [Deleted] BIT NULL DEFAULT 0, 
    [DateDeleted] DATETIME2 NULL , 
    CONSTRAINT FK_Appointments_TenantID FOREIGN KEY (TenantID) REFERENCES Tenants(TenantID)
   
)