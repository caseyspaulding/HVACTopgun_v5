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
    @SubscriptionType NVARCHAR(20),
    @PaymentStatus INT,
    @TrialExpirationDate DATETIME2
AS
BEGIN
    INSERT INTO Tenants (
        FirstName,
        LastName,
        CompanyName,
        Domain,
        Email,
        PhoneNumber,
        [Address],
        City,
        [State],
        ZipCode,
        TimeZone,
        IsActive,
        Deleted,
        SubscriptionType,
        PaymentStatus,
        TrialExpirationDate
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
        @PaymentStatus,
        @TrialExpirationDate
    )
END