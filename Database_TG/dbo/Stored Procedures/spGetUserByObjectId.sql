CREATE PROCEDURE [dbo].[spGetUserByObjectId]
	 @AzureAD_ObjectID NVARCHAR(128)
AS
BEGIN
    SELECT *
    FROM Users
    WHERE AzureAD_ObjectID = @AzureAD_ObjectID
END
