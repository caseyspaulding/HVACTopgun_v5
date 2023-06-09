CREATE PROCEDURE [dbo].[getAllCustomers]

AS
begin
	select *
	from dbo.Customer
end