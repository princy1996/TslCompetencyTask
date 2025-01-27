using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using TslApi.Models.Interfaces;

namespace TslApi
{
    public class DataRetrievalBackground : BackgroundService
    {
        private readonly TimeSpan TimeToWait = TimeSpan.FromSeconds(5); //Set in config
        private readonly ILogger<DataRetrievalBackground> _logger;
        private readonly IHubContext<RaceDataHub, IRaceData> _hub;
        private readonly IDataService _dataService;
        private readonly IConfig _config;

        public DataRetrievalBackground(ILogger<DataRetrievalBackground> logger, IHubContext<RaceDataHub, IRaceData> hub, IDataService data, IConfig config)
        {
            _logger = logger;
            _hub = hub;
            _dataService = data;
            _config = config;
            TimeToWait = TimeSpan.FromSeconds(_config.RaceHubBackgroundInterval);
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
