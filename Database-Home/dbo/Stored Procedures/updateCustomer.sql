CREATE PROCEDURE [dbo].[updateCustomer]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS
begin
	update dbo.Customer
	set FirstName = @FirstName, LastName = @LastName
	where Id = @Id;

end
