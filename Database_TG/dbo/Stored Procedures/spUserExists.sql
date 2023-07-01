CREATE PROCEDURE spUserExists
    @AzureAD_ObjectID NVARCHAR(50)
AS
    SELECT COUNT(1) 
    FROM Users 
    WHERE AzureAD_ObjectID = @AzureAD_ObjectID
GO
