-- Updates an existing chat message
CREATE PROCEDURE spUpdateChatMessage
    @ChatMessageId INT,
    @ChatRoomId INT,
    @SenderId INT,
    @TenantID INT,
    @UserId INT,
    @Message NVARCHAR(MAX),
    @SentDateTime DATETIME,
    @IsRead BIT
AS
BEGIN
    UPDATE [dbo].[ChatMessage]
    SET ChatRoomId = @ChatRoomId,
        SenderId = @SenderId,
        TenantID = @TenantID,
        UserId = @UserId,
        Message = @Message,
        SentDateTime = @SentDateTime,
        IsRead = @IsRead
    WHERE ChatMessageId = @ChatMessageId
END