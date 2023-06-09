CREATE TABLE [dbo].[Appointment] (
    [Id]           INT           NOT NULL IDENTITY,
    [TenantId]     INT           NULL,
    [CustomerId]   INT           NULL,
    [TechnicianId] INT           NULL,
    [StartTime]    DATETIME      NULL,
    [EndTime]      DATETIME      NULL,
    [Status]       VARCHAR (50)  NULL,
    [Notes]        VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id]),
    FOREIGN KEY ([TechnicianId]) REFERENCES [dbo].[Technician] ([Id]),
    FOREIGN KEY ([TenantId]) REFERENCES [dbo].[Tenant] ([Id])
);

