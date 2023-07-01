CREATE PROCEDURE [dbo].[spAddTenant]
	@FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @CompanyName NVARCHAR(50),
    @Domain NVARCHAR(50),
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
    INSERT INTO Tenants (
        FirstName,
        LastName,
        CompanyName,
        Domain,
        Email,
        PhoneNumber,
        Address,
        City,
        State,
        ZipCode,
        TimeZone,
        IsActive,
        Deleted,
        SubscriptionType,
        PaymentStatus
    )
    VALUES (
        @FirstName,
        @LastName,
        @CompanyName,
        @Domain,
        @Email,
        @PhoneNumber,
        @Address,
        @City,
        @State,
        @ZipCode,
        @TimeZone,
        @IsActive,
        @Deleted,
        @SubscriptionType,
        @PaymentStatus
    )
END