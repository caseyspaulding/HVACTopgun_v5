CREATE PROCEDURE [dbo].[spUpdateUser]
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
    UPDATE dbo.Users
    SET
        TenantID = @TenantID,
        UserName = @UserName,
        Email = @Email,
        FirstName = @FirstName,
        LastName = @LastName,
        PhoneNumber = @PhoneNumber,
        Deleted = @Deleted,
        DateDeleted = @DateDeleted,
        Role = @Role,
        AzureAD_ObjectID = @AzureAD_ObjectID
    WHERE
        UserId = @UserId;
END