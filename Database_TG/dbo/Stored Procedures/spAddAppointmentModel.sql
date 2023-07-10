CREATE PROCEDURE [dbo].[spAddAppointmentModel]
    @TenantID INT,
    @UserID INT,
    @Subject NVARCHAR(100),
    @Description NVARCHAR(100),
    @StartTime DATETIME2,
    @EndTime DATETIME2,
    @TechnicianName NVARCHAR(50),
    @CustomerName NVARCHAR(100),
    @Location NVARCHAR(100),
    @Status INT,
    @IsAllDay BIT,
    @RecurrenceID INT,
    @RecurrenceRule NVARCHAR(500),
    @RecurrenceException NVARCHAR(500),
    @IsReadonly BIT,
    @IsBlock BIT,
    @CssClass NVARCHAR(100),
    @AvailableAppointmentId INT,
    @TenantName NVARCHAR(100),
    @CategoryColor NVARCHAR(20),
    @StartTimeZone NVARCHAR(100),
    @EndTimeZone NVARCHAR(100),
    @TechnicianId INT,
    @CustomerId INT,
    @ServiceId INT,
    @Deleted BIT,
    @JobTypeId INT
AS
BEGIN
    INSERT INTO Appointments (
       
        TenantID, UserID, Subject, Description, StartTime, EndTime, TechnicianName, CustomerName, Location, Status, IsAllDay, RecurrenceID, RecurrenceRule, RecurrenceException, IsReadonly, IsBlock, CssClass, AvailableAppointmentId, TenantName, CategoryColor, StartTimeZone, EndTimeZone, TechnicianId, CustomerId, ServiceId, Deleted, JobTypeId)
    VALUES (
       
        @TenantID, @UserID, @Subject, @Description, @StartTime, @EndTime, @TechnicianName, @CustomerName, @Location, @Status, @IsAllDay, @RecurrenceID, @RecurrenceRule, @RecurrenceException, @IsReadonly, @IsBlock, @CssClass, @AvailableAppointmentId, @TenantName, @CategoryColor, @StartTimeZone, @EndTimeZone, @TechnicianId, @CustomerId, @ServiceId, @Deleted, @JobTypeId)
END