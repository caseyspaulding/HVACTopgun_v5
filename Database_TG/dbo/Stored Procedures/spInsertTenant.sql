CREATE PROCEDURE [dbo].[spInsertTenant]
	@FirstName NVARCHAR(50), 
    @LastName NVARCHAR(50), 
    @CompanyName NVARCHAR(50),
    @Domain NVARCHAR(50),
    @Email NVARCHAR(100),
    @PhoneNumber NVARCHAR(20),
    @Address NVARCHAR(100),
    @City NVARCHAR(50),
    @State NVARCHAR(20),
    @Zipcode NVARCHAR(20),
    @TimeZone NVARCHAR(50),
    @SubscriptionType INT,
    @PaymentStatus INT
AS
	INSERT INTO Tenants (
        FirstName, LastName, CompanyName, Domain, Email, PhoneNumber, 
        Address, City, State, Zipcode, TimeZone, SubscriptionType, PaymentStatus
    )
    OUTPUT INSERTED.TenantID
    VALUES (
        @FirstName, @LastName, @CompanyName, @Domain, @Email, @PhoneNumber, 
        @Address, @City, @State, @Zipcode, @TimeZone, @SubscriptionType, @PaymentStatus
    )
GO

