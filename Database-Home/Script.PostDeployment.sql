/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
--------------------------------------------------------------------------------------
*/

if not exists (select 1 from dbo.Customer)
begin
    insert into dbo.Customer (FirstName, LastName)
    values ('Bruce', 'Wayne'),
    ('James', 'Kirk'),
    ('Casey', 'Spaulding'),
    ('John', 'Smith');
end
