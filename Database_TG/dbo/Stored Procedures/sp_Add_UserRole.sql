CREATE PROCEDURE [dbo].[sp_Add_UserRole]
	@UserId int,
	@RoleId int
AS
	INSERT INTO [dbo].[UserRole] (UserId, RoleId) VALUES (@UserId, @RoleId)
RETURN 0
