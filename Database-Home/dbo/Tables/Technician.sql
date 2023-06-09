CREATE TABLE [dbo].[Technician] (
    [Id]        INT           NOT NULL IDENTITY,
    [TenantId]  INT           NULL,
    [FirstName] VARCHAR (50)  NULL,
    [LastName]  VARCHAR (50)  NULL,
    [Email]     VARCHAR (100) NULL,
    [Phone]     VARCHAR (20)  NULL,
    [IsActive]  BIT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([TenantId]) REFERENCES [dbo].[Tenant] ([Id])
);

