using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace TslApi
{
    public class RaceDataHub : Hub<IRaceData>
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId).ServerMessage($"User {Context.User?.Identity?.Name} Connected");
            Debug.WriteLine($"User {Context.User?.Identity?.Name} Connected");
            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string message)
        {
            await Clients.Client(Context.ConnectionId).ServerMessage(message);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Debug.WriteLine($"User {Context.User?.Identity?.Name} disconnected because {exception}");

            await base.OnDisconnectedAsync(exception);
        }
    }

    public interface IRaceData
    {
        Task ServerMessage(string message);
        Task SendTimes(string message);
    }
}
