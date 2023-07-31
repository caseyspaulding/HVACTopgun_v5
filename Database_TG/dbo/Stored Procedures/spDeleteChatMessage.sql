CREATE PROCEDURE spDeleteChatMessage
    @ChatMessageId INT
AS
BEGIN
    UPDATE [dbo].[ChatMessage]
    SET IsDeleted = 1
    WHERE ChatMessageId = @ChatMessageId
END
