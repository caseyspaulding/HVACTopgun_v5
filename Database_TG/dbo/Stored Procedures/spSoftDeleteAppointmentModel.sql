CREATE PROCEDURE [dbo].[spSoftDeleteAppointmentModel]
	 @Id INT,
    @TenantID INT
AS
BEGIN
    UPDATE Appointments
    SET Deleted = 1,
        DateDeleted = GETDATE()
    WHERE Id = @Id AND TenantID = @TenantID
END
