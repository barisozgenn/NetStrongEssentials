using Microsoft.AspNetCore.SignalR;

namespace A_BasicClientServer;

public class GroupsHub: Hub
{
    public async Task JoinGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }

    public Task SendMessageToGroup(string groupName)
    {
        return Clients.Group(groupName).SendAsync("GroupMessage", groupName);
    }
}
