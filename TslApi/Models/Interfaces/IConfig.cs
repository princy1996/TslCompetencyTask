namespace TslApi.Models.Interfaces
{
    public interface IConfig
    {
        public string ConnectionString { get; set; }
        public int RaceHubBackgroundInterval { get; set; }
    }
}
