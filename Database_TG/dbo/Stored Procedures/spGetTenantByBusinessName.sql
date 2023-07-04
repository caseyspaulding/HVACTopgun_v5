CREATE PROCEDURE [dbo].[spGetTenantByBusinessName]
	  @CompanyName NVARCHAR(50)
AS
BEGIN
    SELECT *
    FROM Tenants
    WHERE CompanyName = @CompanyName
END
