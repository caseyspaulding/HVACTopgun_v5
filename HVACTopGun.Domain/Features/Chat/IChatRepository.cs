namespace HVACTopGun.Domain.Features.Chat;
public interface IChatRepository
{
    Task<IEnumerable<ChatMessageModel>> GetAllMessages();
    Task<IEnumerable<ChatMessageModel>> GetAllMessagesByTenantId(int tenantId); // Add this line
    Task<int> InsertMessage(ChatMessageModel message);
    Task UpdateMessage(ChatMessageModel message);
    Task DeleteMessage(int messageId);
}