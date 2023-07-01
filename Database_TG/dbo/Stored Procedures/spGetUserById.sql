CREATE PROCEDURE [dbo].[spGetUserById]
	 @UserId INT
AS
BEGIN
    SELECT *
    FROM dbo.Users
    WHERE UserId = @UserId;
END