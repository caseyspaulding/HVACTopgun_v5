CREATE TABLE [dbo].[ChatbotConversations]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
   [TenantID] INT FOREIGN KEY REFERENCES Tenants([TenantID]),
    [CustomerId] INT NOT NULL,
    [ConversationId] NVARCHAR(100) NULL,
    [Messages] NVARCHAR(MAX) NULL,
    [Conversation] NVARCHAR(MAX) NULL,
    [CreatedDate] DATETIME NULL,
    [LastModifiedDate] DATETIME NULL,
    CONSTRAINT FK_ChatbotConversations_TenantID FOREIGN KEY (TenantID) REFERENCES Tenants(TenantID)
)
