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
    [TechnicianName] NVARCHAR(100) NULL,
    [CustomerName] NVARCHAR(100) NULL,
    [Location] NVARCHAR(100) NULL,
    [Status] INT NOT NULL,
    [IsAllDay] BIT NOT NULL,
    [RecurrenceID] INT NULL,
    [RecurrenceRule] NVARCHAR(500) NULL,
    [RecurrenceException] NVARCHAR(500) NULL,
    [IsReadonly] BIT NOT NULL,
    [IsBlock] BIT NOT NULL,
    [CssClass] NVARCHAR(100) NULL,
    [AvailableAppointmentId] INT NOT NULL,
    [TenantName] NVARCHAR(100) NOT NULL,
    [CategoryColor] NVARCHAR(20) NULL,
    [StartTimeZone] NVARCHAR(100) NULL,
    [EndTimeZone] NVARCHAR(100) NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
    [UpdatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
    [TechnicianId] INT NOT NULL,
    [JobTypeId] INT NOT NULL, 
    [JobStatus] BIT NULL, 
    CONSTRAINT FK_Appointments_TenantID FOREIGN KEY (TenantID) REFERENCES Tenants(TenantID)
   
)