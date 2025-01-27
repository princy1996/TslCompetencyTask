using TslApi.Models.Interfaces;

namespace TslApi.Models
{
    public class Config : IConfig
    {
        public string ConnectionString { get; set; }
        public int RaceHubBackgroundInterval { get; set; }
    }
}
