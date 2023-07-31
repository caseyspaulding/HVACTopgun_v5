namespace HVACTopGun.Domain.Features.Chat;
public class ChatRoomModel
{
    public int ChatRoomId { get; set; }
    public int TenantID { get; set; }
    public int UserId { get; set; }
    public int AgentId { get; set; }
    public string VisitorName { get; set; }
    public DateTime StartedDateTime { get; set; }
    public DateTime? EndedDateTime { get; set; }
    public bool IsClosed { get; set; }
    public bool IsVisitorOnline { get; set; }
    public DateTime LastActiveDateTime { get; set; }
    public int ChatAgentId { get; set; }


}
