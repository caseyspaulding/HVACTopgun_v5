CREATE TABLE [dbo].[Appointments]
(
	[AppointmentID] INT NOT NULL PRIMARY KEY IDENTITY,
    [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]), -- If associated with a tenant
    [CustomerID] INT FOREIGN KEY REFERENCES Customers([CustomerID]), -- If associated with a customer
    [ServiceID] INT FOREIGN KEY REFERENCES Services([ServiceID]), -- If associated with a service
    [UserID] INT FOREIGN KEY REFERENCES Users([UserID]), -- If associated with a User (like a staff member)
    [Subject] NVARCHAR(100) NULL,
    [Description] NVARCHAR(100) NULL,
    [StartTime] DATETIME2 NOT NULL,
    [EndTime] DATETIME2 NOT NULL,
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
    [CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
    [UpdatedAt] DATETIME2 NULL DEFAULT GETDATE(),
    [TechnicianId] INT NULL,
    [JobTypeId] INT NULL, 
    [JobStatus] BIT NULL, 
    [Deleted] BIT NOT NULL DEFAULT 0, 
    [DateDeleted] DATETIME2 NULL , 
    CONSTRAINT FK_Appointments_TenantID FOREIGN KEY (TenantID) REFERENCES Tenants(TenantID)
   
)