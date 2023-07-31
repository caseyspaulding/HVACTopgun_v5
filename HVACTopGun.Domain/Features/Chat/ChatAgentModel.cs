namespace HVACTopGun.Domain.Features.Chat;
public class ChatAgentModel
{
    public int ChatAgentId { get; set; }
    public int TenantID { get; set; }
    public int UserId { get; set; }
    public string? AgentName { get; set; }
    public string? AgentEmail { get; set; }
    // Add any other properties related to agents if needed
}
