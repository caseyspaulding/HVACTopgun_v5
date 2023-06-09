CREATE PROCEDURE [dbo].[deleteCustomer]
	@Id int
AS
begin
	delete
	from dbo.Customer
	where Id = @Id;
end
