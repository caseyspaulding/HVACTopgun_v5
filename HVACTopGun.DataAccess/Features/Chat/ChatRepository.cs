using HVACTopGun.DataAccess.DataAccess;
using HVACTopGun.Domain.Features.Chat;

namespace HVACTopGun.DataAccess.Features.Chat;
public class ChatRepository : IChatRepository
{
    private readonly ISqlDataAccess _sqlDataAccess;

    public ChatRepository(ISqlDataAccess sqlDataAccess)
    {
        _sqlDataAccess = sqlDataAccess;
    }

    public async Task<IEnumerable<ChatMessageModel>> GetAllMessages()
    {
        return await _sqlDataAccess.LoadData<ChatMessageModel, dynamic>("spGetAllChatMessages", new { });
    }

    public async Task<int> InsertMessage(ChatMessageModel message)
    {
        return await _sqlDataAccess.InsertDataReturnId("spInsertChatMessage", message);
    }

    public async Task UpdateMessage(ChatMessageModel message)
    {
        await _sqlDataAccess.SaveData("spUpdateChatMessage", message);
    }

    public async Task DeleteMessage(int messageId)
    {
        await _sqlDataAccess.SaveData("spDeleteChatMessage", new { ChatMessageId = messageId });
    }

    public Task<IEnumerable<ChatMessageModel>> GetAllMessagesByTenantId(int tenantId)
    {
        throw new NotImplementedException();
    }
}

