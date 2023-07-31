using HVACTopGun.Services.Features.Tenants;
using HVACTopGun.Services.Features.Users;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace HVACTopGun.Services.Features.ChatHub;
public class ChatSignalRHub : Hub
{
    public const string HubUrl = "/ChatSignalRHub"; // Define a constant for the hub URL
    private readonly ITenantService _tenantService;
    private readonly IUserService _userService;
    private static readonly ConcurrentDictionary<string, int> connectionTenantMapping = new ConcurrentDictionary<string, int>(); // Define the mapping here

    public ChatSignalRHub(ITenantService tenantService, IUserService userService)
    {
        _tenantService = tenantService;
        _userService = userService;
    }
    public async Task Broadcast(string username, string message) // Renamed to "Broadcast"
    {
        await Clients.All.SendAsync("ReceiveMessage", username, message); // Send to all connected clients
    }

    public async override Task OnConnectedAsync()
    {
        // Retrieve user's objectId from the claims
        var objectId = Context.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;

        if (objectId != null)
        {
            // Retrieve tenant ID and user ID using the objectId
            int? tenantId = await _tenantService.GetTenantIdByObjectId(objectId);
            int? userId = await _userService.GetUserIdByObjectId(objectId);

            if (tenantId.HasValue)
            {
                // Add the connection to a group named after the tenant ID
                await Groups.AddToGroupAsync(Context.ConnectionId, tenantId.ToString());

                // Store the connection ID and tenant ID in the mapping
                connectionTenantMapping[Context.ConnectionId] = tenantId.Value;
                Console.WriteLine($"Added {Context.ConnectionId} to group {tenantId}");
            }
        }

        await base.OnConnectedAsync();
    }
    public override async Task OnDisconnectedAsync(Exception e)
    {
        // Try to retrieve the tenant ID from the mapping
        if (connectionTenantMapping.TryRemove(Context.ConnectionId, out int tenantId))
        {
            // You can now use tenantId here for any tenant-specific logic you need
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, tenantId.ToString());
            Console.WriteLine($"Connection {Context.ConnectionId} for tenant {tenantId} disconnected");
        }
        else
        {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}"); // Log the disconnection
        }

        await base.OnDisconnectedAsync(e);
    }

}

