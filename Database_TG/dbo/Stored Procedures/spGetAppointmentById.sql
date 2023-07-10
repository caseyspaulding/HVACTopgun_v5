CREATE PROCEDURE [dbo].[spGetAppointmentById]
    @Id INT,
    @TenantID INT
AS
BEGIN
    SELECT *
    FROM Appointments
    WHERE Id = @Id AND TenantID = @TenantID
END
