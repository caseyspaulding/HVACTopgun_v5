namespace DataAccess.Models
{
    public interface IChatbotConversations
    {
        string? Conversation { get; set; }
        string? ConversationId { get; set; }
        DateTime? CreatedDate { get; set; }
        int CustomerId { get; set; }
        int Id { get; set; }
        DateTime? LastModifiedDate { get; set; }
        string? Messages { get; set; }
        int TenantId { get; set; }
    }
}