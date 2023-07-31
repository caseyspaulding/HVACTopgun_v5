-- Inserts a new chat message and returns the new message ID
CREATE PROCEDURE spInsertChatMessage
    @ChatRoomId INT,
    @SenderId INT,
    @TenantID INT,
    @UserId INT,
    @Message NVARCHAR(MAX),
    @SentDateTime DATETIME,
    @IsRead BIT
AS
BEGIN
    INSERT INTO [dbo].[ChatMessage] (ChatRoomId, SenderId, TenantID, UserId, Message, SentDateTime, IsRead)
    VALUES (@ChatRoomId, @SenderId, @TenantID, @UserId, @Message, @SentDateTime, @IsRead)

    SELECT SCOPE_IDENTITY() AS ChatMessageId
END
