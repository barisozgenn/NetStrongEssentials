using Microsoft.AspNetCore.SignalR;

namespace A_BasicClientServer;

public class MusicPlayCountHub : Hub
{
    private static int MusicPlayCount {get;set;} = 0;

    public Task IncrementMusicPlayCountOnServer()
    {
        MusicPlayCount++;
        return Clients.All.SendAsync("incrementMusicPlayCount", MusicPlayCount);
    }
}