CREATE PROCEDURE [dbo].[spAddAppointmentModel]
@TenantID INT,
    @UserID INT,
    @Subject NVARCHAR(50),
    @Description NVARCHAR(MAX),
    @StartTime DATETIME,
    @EndTime DATETIME,
    @TechnicianName NVARCHAR(50),
    @CustomerName NVARCHAR(50),
    @Location NVARCHAR(100),
    @Status INT,
    @IsAllDay BIT,
    @RecurrenceID INT,
    @RecurrenceRule NVARCHAR(200),
    @RecurrenceException NVARCHAR(200),
    @IsReadonly BIT,
    @IsBlock BIT,
    @CssClass NVARCHAR(50),
    @AvailableAppointmentId INT,
    @TenantName NVARCHAR(50),
    @CategoryColor NVARCHAR(10),
    @StartTimeZone NVARCHAR(50),
    @EndTimeZone NVARCHAR(50),
    @CreatedAt DATETIME,
    @UpdatedAt DATETIME,
    @TechnicianId INT,
    @CustomerId INT,
    @ServiceID INT,
    @Deleted BIT,
    @DateDeleted DATETIME,
    @JobTypeId INT
AS
BEGIN
    INSERT INTO Appointments (
        TenantID, UserID, Subject, Description, StartTime, EndTime, TechnicianName, CustomerName, Location, Status, IsAllDay, RecurrenceID, RecurrenceRule, RecurrenceException, IsReadonly, IsBlock, CssClass, AvailableAppointmentId, TenantName, CategoryColor, StartTimeZone, EndTimeZone, CreatedAt, UpdatedAt, TechnicianId, CustomerId, ServiceID, Deleted, DateDeleted, JobTypeId)
    VALUES (
        @TenantID, @UserID, @Subject, @Description, @StartTime, @EndTime, @TechnicianName, @CustomerName, @Location, @Status, @IsAllDay, @RecurrenceID, @RecurrenceRule, @RecurrenceException, @IsReadonly, @IsBlock, @CssClass, @AvailableAppointmentId, @TenantName, @CategoryColor, @StartTimeZone, @EndTimeZone, @CreatedAt, @UpdatedAt, @TechnicianId, @CustomerId, @ServiceID, @Deleted, @DateDeleted, @JobTypeId)
END