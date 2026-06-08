using Microsoft.AspNetCore.SignalR;

namespace Doccure.QueueService.Hubs
{
    public class QueueHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}
