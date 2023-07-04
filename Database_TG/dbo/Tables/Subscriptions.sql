CREATE TABLE [dbo].[Subscriptions]
(
    [SubscriptionId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [SubscriptionType] NVARCHAR(20) NOT NULL,
    [SubscriptionDescription] NVARCHAR(50) NULL,
    [Price] DECIMAL(10, 2) NOT NULL,
    [Features] NVARCHAR(100) NULL,
    [Deleted] BIT NOT NULL DEFAULT 0, 
    [DateDeleted] DATETIME2 NULL, 
    [Status] NCHAR(10) NULL, 
)
