CREATE TABLE [dbo].[TenantSubscriptions]
(
    [TenantId] INT NOT NULL,
    [SubscriptionId] INT NOT NULL,
    [Status] NVARCHAR(50) NULL,
    [StartDate] DATETIME2 NOT NULL,
    [EndDate] DATETIME2 NOT NULL,
    CONSTRAINT [PK_TenantSubscriptions] PRIMARY KEY CLUSTERED 
    (
        [TenantId] ASC,
        [SubscriptionId] ASC
    ),
    CONSTRAINT [FK_TenantSubscriptions_Tenants] FOREIGN KEY (TenantId) REFERENCES [dbo].[Tenants](TenantId),
    CONSTRAINT [FK_TenantSubscriptions_Subscriptions] FOREIGN KEY (SubscriptionId) REFERENCES [dbo].[Subscriptions](SubscriptionId)
)