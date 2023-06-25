using DataAccess.Models.Interfaces;

namespace DataAccess.Models
{
    public class ChatbotConversations : IChatbotConversations
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int CustomerId { get; set; }
        public string? ConversationId { get; set; }
        public string? Messages { get; set; }
        public string? Conversation { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
