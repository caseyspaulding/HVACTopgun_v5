CREATE PROCEDURE [dbo].[spInsertUser]
	 @TenantID INT,
    @AzureAD_ObjectID NVARCHAR(50), 
    @Role NVARCHAR(50),
    @UserName NVARCHAR(50),
    @Email NVARCHAR(100),
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @PhoneNumber NVARCHAR(20)
AS
	INSERT INTO Users (
        TenantID, AzureAD_ObjectID, Role, UserName, Email, FirstName, LastName, PhoneNumber
    )
    VALUES (
        @TenantID, @AzureAD_ObjectID, @Role, @UserName, @Email, @FirstName, @LastName, @PhoneNumber
    )
GO
