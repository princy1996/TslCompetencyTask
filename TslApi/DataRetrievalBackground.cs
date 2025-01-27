using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace TslApi
{
    public class DataRetrievalBackground : BackgroundService
    {
        private static readonly TimeSpan TimeToWait = TimeSpan.FromSeconds(5); //Set in config
        private readonly ILogger<DataRetrievalBackground> _logger;
        private readonly IHubContext<RaceDataHub, IRaceData> _hub;
        private readonly IDataService _dataService;

        public DataRetrievalBackground(ILogger<DataRetrievalBackground> logger, IHubContext<RaceDataHub, IRaceData> hub, IDataService data)
        {
            _logger = logger;
            _hub = hub;
            _dataService = data;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(TimeToWait);
            while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                var datetime = DateTime.UtcNow;
                Debug.WriteLine($"Send Data at {datetime}");
                //await _hub.Clients.All.ServerMessage($"Server message sent {datetime}");
                try
                {
                    await _hub.Clients.All.SendRaceData(await _dataService.GetRaceData());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    await _hub.Clients.All.ErrorNotification($"An error has occured: {ex}"); //Could expand
                }
            }
        }
    }
}
