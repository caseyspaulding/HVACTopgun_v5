CREATE PROCEDURE [dbo].[getCustomer]
	@Id int
AS
begin
	select *
	from dbo.Customer
	where Id = @Id;
end
