
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

// The ProductViewersHub class represents a SignalR hub
public class ProductViewersHub : Hub
{
    public static int ProductViewersCount { get; set; } = 0;

    // Method to notify clients about the updated product viewers count.

    public async Task NotifyProductViewers()
    {
        // Increment
        ProductViewersCount++;
        // Notify all connected clients about the updated count using the "productViewersCountUpdate" method.
        await this.Clients.All.SendAsync("productViewersCountUpdate", ProductViewersCount);
    }
}
