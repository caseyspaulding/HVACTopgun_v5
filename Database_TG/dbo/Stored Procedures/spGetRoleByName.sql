CREATE PROCEDURE [dbo].[spGetRoleByName]
	@RoleName VARCHAR(50)
AS
BEGIN
    SELECT *
    FROM [dbo].[Roles]
    WHERE [RoleName] = @RoleName
END