using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace TslApi
{
    public class DataRetrievalBackground : BackgroundService
    {
        private static readonly TimeSpan TimeToWait = TimeSpan.FromSeconds(1);
        private readonly ILogger<DataRetrievalBackground> _logger;
        private readonly IHubContext<RaceDataHub, IRaceData> _hub;

        public DataRetrievalBackground(ILogger<DataRetrievalBackground> logger, IHubContext<RaceDataHub, IRaceData> hub)
        {
            _logger = logger;
            _hub = hub;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(TimeToWait);
            while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                var datetime = DateTime.UtcNow;
                Debug.WriteLine($"Send Data at {datetime}");
                _logger.LogInformation($"Send Data at {datetime} from within {nameof(DataRetrievalBackground)}");
                await _hub.Clients.All.ServerMessage($"Server message sent {datetime}");
            }
        }
    }
}
