CREATE TABLE [dbo].[Tenant] (
    [Id]      INT           NOT NULL IDENTITY,
    [Name]    VARCHAR (100) NULL,
    [Email]   VARCHAR (100) NULL,
    [Phone]   VARCHAR (20)  NULL,
    [Address] VARCHAR (100) NULL,
    [City]    VARCHAR (50)  NULL,
    [State]   VARCHAR (50)  NULL,
    [ZipCode] VARCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

