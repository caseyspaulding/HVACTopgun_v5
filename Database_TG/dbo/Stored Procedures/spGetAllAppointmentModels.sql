CREATE PROCEDURE spGetAllAppointmentModels
    @TenantID INT
AS
BEGIN
    SELECT *
    FROM Appointments
    WHERE TenantID = @TenantID  AND (Deleted IS NULL OR Deleted = 0)
END