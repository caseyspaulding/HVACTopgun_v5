CREATE PROCEDURE [dbo].[spGetTenant]
  @Id INT
AS
BEGIN
    SELECT *
    FROM dbo.Tenants
    WHERE TenantID = @Id
END