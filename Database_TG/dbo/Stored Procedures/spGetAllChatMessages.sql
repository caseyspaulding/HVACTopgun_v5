-- Retrieves all chat messages
CREATE PROCEDURE spGetAllChatMessages
AS
BEGIN
    SELECT * FROM [dbo].[ChatMessage]
END