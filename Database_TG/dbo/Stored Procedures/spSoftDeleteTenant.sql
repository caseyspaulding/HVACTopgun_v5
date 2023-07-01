CREATE PROCEDURE [dbo].[spSoftDeleteTenant]
	@TenantID INT
AS
BEGIN
    -- Soft delete the tenant
    UPDATE Tenants
    SET Deleted = 1
    WHERE TenantID = @TenantID

    -- Also, if you want to soft delete all associated users:
    UPDATE Users
    SET Deleted = 1
    WHERE TenantID = @TenantID
END
