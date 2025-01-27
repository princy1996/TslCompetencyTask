using TslApi.Models.Interfaces;

namespace TslApi.Models
{
    public class Config
    {
        public const string ConfigRef = "AppConfig";

        public string ConnectionString { get; set; }
        public int RaceHubBackgroundInterval { get; set; }
    }
}
