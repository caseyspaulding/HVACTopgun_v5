CREATE PROCEDURE spGetAllAppointmentModels
    @TenantID INT
AS
BEGIN
    SELECT *
    FROM Appointments
    WHERE TenantID = @TenantID
END