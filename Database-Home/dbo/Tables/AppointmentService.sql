CREATE TABLE [dbo].[AppointmentService] (
    [Id]            INT NOT NULL IDENTITY,
    [AppointmentId] INT NULL,
    [ServiceId]     INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AppointmentId]) REFERENCES [dbo].[Appointment] ([Id]),
    FOREIGN KEY ([ServiceId]) REFERENCES [dbo].[Service] ([Id])
);

