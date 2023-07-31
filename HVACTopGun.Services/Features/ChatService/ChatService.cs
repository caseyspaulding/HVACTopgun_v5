using HVACTopGun.Domain.Features.Chat;
using HVACTopGun.Services.Features.ChatHub;
using Microsoft.AspNetCore.SignalR;

namespace HVACTopGun.Services.Features.ChatService
{
    public class ChatService
    {
        private readonly IHubContext<ChatSignalRHub> _hubContext;
        private readonly IChatRepository _chatRepository;

        public ChatService(IHubContext<ChatSignalRHub> hubContext, IChatRepository chatRepository)
        {
            _hubContext = hubContext;
            _chatRepository = chatRepository;
        }

        public async Task SendTenantMessage(int tenantId, int userId, string message)
        {
            // Create a ChatMessageModel
            var chatMessage = new ChatMessageModel
            {
                TenantID = tenantId,
                UserId = userId,
                Message = message,
                SentDateTime = DateTime.UtcNow,
                IsRead = false,
                IsDeleted = false
                // Set other properties as needed
            };

            // Insert the message into the database using a stored procedure
            await _chatRepository.InsertMessage(chatMessage);

            // Broadcast the message to the appropriate group
            await _hubContext.Clients.Group(tenantId.ToString()).SendAsync("ReceiveMessage", chatMessage);
        }

        // Example of retrieving all messages for a specific tenant
        public async Task<IEnumerable<ChatMessageModel>> GetChatHistory(int tenantId)
        {
            // Assuming your repository method is filtering by tenantId using a stored procedure
            return await _chatRepository.GetAllMessagesByTenantId(tenantId);
        }



        // Example of updating a message
        public async Task UpdateMessage(ChatMessageModel message)
        {
            await _chatRepository.UpdateMessage(message);
        }

        // Example of deleting a message
        public async Task DeleteMessage(int messageId)
        {
            await _chatRepository.DeleteMessage(messageId);
        }
    }
}
