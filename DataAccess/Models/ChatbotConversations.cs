

namespace DataAccess.Models
{
    public class ChatbotConversations
    {
        public int Id { get; set; }
        public int TenantID { get; set; }
        public int CustomerId { get; set; }
        public string? ConversationId { get; set; }
        public string? Messages { get; set; }
        public string? Conversation { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime DateDeleted { get; set; }
    }
}
