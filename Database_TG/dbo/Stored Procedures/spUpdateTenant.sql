CREATE PROCEDURE [dbo].[spUpdateTenant]
	 @TenantID INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @CompanyName NVARCHAR(50),
    @Domain NVARCHAR(50),
    @LastUpdated DATETIME2,
    @Email NVARCHAR(100),
    @PhoneNumber NVARCHAR(20),
    @Address NVARCHAR(100),
    @City NVARCHAR(50),
    @State NVARCHAR(20),
    @ZipCode NVARCHAR(20),
    @TimeZone NVARCHAR(50),
    @IsActive BIT,
    @Deleted BIT,
    @SubscriptionType INT,
    @PaymentStatus INT
AS
BEGIN
    UPDATE Tenants
    SET
        FirstName = @FirstName,
        LastName = @LastName,
        CompanyName = @CompanyName,
        Domain = @Domain,
        LastUpdated = @LastUpdated,
        Email = @Email,
        PhoneNumber = @PhoneNumber,
        Address = @Address,
        City = @City,
        State = @State,
        ZipCode = @ZipCode,
        TimeZone = @TimeZone,
        IsActive = @IsActive,
        Deleted = @Deleted,
        SubscriptionType = @SubscriptionType,
        PaymentStatus = @PaymentStatus
    WHERE
        TenantID = @TenantID
END
