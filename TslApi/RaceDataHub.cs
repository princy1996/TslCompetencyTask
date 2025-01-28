using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using TslApi.DTOs.Interface;

namespace TslApi
{
    [Authorize]
    public class RaceDataHub : Hub<IRaceData>
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId).ServerMessage($"User {Context.User?.Identity?.Name} Connected");
            Debug.WriteLine($"User {Context.User?.Identity?.Name} Connected"); //Remove outside of dev or use middlewear
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Debug.WriteLine($"User {Context.User?.Identity?.Name} disconnected because {exception}");//as above

            await base.OnDisconnectedAsync(exception);
        }
    }

    /// <summary>
    /// Interface for RaceData hub explicit typing
    /// </summary>
    public interface IRaceData
    {
        Task ServerMessage(string message);
        Task SendRaceData(IRaceDataDto raceDataDto);
        Task ErrorNotification(string message);
    }
}
