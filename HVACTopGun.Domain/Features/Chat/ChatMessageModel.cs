namespace HVACTopGun.Domain.Features.Chat;
public class ChatMessageModel
{
    public int ChatMessageId { get; set; }
    public int ChatRoomId { get; set; }
    public int SenderId { get; set; }
    public int TenantID { get; set; } // New field to identify the tenant
    public int UserId { get; set; }   // New field to identify the user who sent the message
    public string? Message { get; set; }
    public DateTime SentDateTime { get; set; }
    public bool IsRead { get; set; }
    public bool IsDeleted { get; set; }
}
