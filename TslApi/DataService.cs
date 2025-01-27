using Newtonsoft.Json;
using TslApi.DTOs.Interface;
using TslApi.DTOs.Models;

namespace TslApi
{
    public class DataService : IDataService
    {
        private readonly ILogger<DataService> _logger;

        public DataService(ILogger<DataService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets Racedata from external API async
        /// </summary>
        /// <returns><paramref name="IRaceDataDto"></para></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<IRaceDataDto?> GetRaceData()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync("http://dev-sample-api.tsl-timing.com/sample-data"); //Add to config
            _logger.LogInformation($"{nameof(DataService)} Returned Status code {responseMessage.StatusCode} with reason {responseMessage.ReasonPhrase} at {DateTime.UtcNow}");

            if (responseMessage.IsSuccessStatusCode)
            {
                JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                //Only from trusted sources
                var test = responseMessage.Content.ReadAsStringAsync().Result;
                RaceDataDto? raceData = JsonConvert.DeserializeObject<RaceDataDto?>(responseMessage.Content.ReadAsStringAsync().Result, serializerSettings);

                return raceData;
            }
            else
            {
                throw new ArgumentException($"Api returned unsuccessful status code: {responseMessage.StatusCode} With Reason : {responseMessage.ReasonPhrase}");
            }
        }
    }
}
