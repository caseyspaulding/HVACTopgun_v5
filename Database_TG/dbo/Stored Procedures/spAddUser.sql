CREATE PROCEDURE [dbo].[spAddUser]
	  @UserId INT,
    @TenantID INT,
    @UserName NVARCHAR(50),
    @Email NVARCHAR(100),
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @PhoneNumber NVARCHAR(20),
    @Deleted BIT,
    @DateDeleted DATETIME2,
    @Role NVARCHAR(50),
    @AzureAD_ObjectID NVARCHAR(50)
AS
BEGIN
    INSERT INTO dbo.Users (TenantID, UserName, Email, FirstName, LastName, PhoneNumber, Deleted, DateDeleted, Role, AzureAD_ObjectID)
    VALUES (@TenantID, @UserName, @Email, @FirstName, @LastName, @PhoneNumber, @Deleted, @DateDeleted, @Role, @AzureAD_ObjectID);
END