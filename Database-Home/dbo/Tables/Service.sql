CREATE TABLE [dbo].[Service] (
    [Id]          INT             NOT NULL IDENTITY,
    [Name]        VARCHAR (100)   NULL,
    [Description] VARCHAR (MAX)   NULL,
    [Price]       DECIMAL (10, 2) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

