CREATE PROCEDURE [dbo].[spSoftDeleteAppointmentModel]
	 @AppointmentID INT,
    @TenantID INT
AS
BEGIN
    UPDATE Appointments
    SET Deleted = 1,
        DateDeleted = GETDATE()
    WHERE AppointmentID = @AppointmentID AND TenantID = @TenantID
END
