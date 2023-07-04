CREATE TABLE [dbo].[Roles]
(
    [RoleId] INT NOT NULL PRIMARY KEY Identity,
    [RoleName] NVARCHAR(100) NULL,
    [RoleDescription] NVARCHAR(MAX) NULL,
    [RoleType] NVARCHAR(100) NULL
)
