namespace TslApi.Models.Interfaces
{
    public interface IConfig
    {
        public const string Config = "AppConfig";
        public string ConnectionString { get; set; }
        public int RaceHubBackgroundInterval { get; set; }
    }
}
