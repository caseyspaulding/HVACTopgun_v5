CREATE TABLE [dbo].[Customer] (
    [Id]        INT           NOT NULL IDENTITY,
    [TenantId]  INT           NULL,
    [FirstName] VARCHAR (50)  NOT NULL,
    [LastName]  VARCHAR (50)  NOT NULL,
    [Email]     VARCHAR (100) NULL,
    [Phone]     VARCHAR (20)  NULL,
    [Address]   VARCHAR (100) NULL,
    [City]      VARCHAR (50)  NULL,
    [State]     VARCHAR (50)  NULL,
    [ZipCode]   VARCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([TenantId]) REFERENCES [dbo].[Tenant] ([Id])
);

