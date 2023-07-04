CREATE PROCEDURE [dbo].[spGetTenantIdByObjectId]
	@ObjectId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT TenantID FROM Users WHERE AzureAD_ObjectID = @ObjectId
END
