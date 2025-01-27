using TslApi.DTOs.Interface;

namespace TslApi.DTOs.Models
{
    public class CompetitorDto : ICompetitorDto
    {
        //Add Json properties instead of raw view
        public required string id { get; set; }
        public string? startNumber { get; set; }
        public string? name { get; set; }
        public string? teamName { get; set; }
        public string? className { get; set; }
        public int? position { get; set; }
        public bool finished { get; set; }
        public int laps { get; set; }
        public required TimeDto fastestLapTime { get; set; }
        public required TimeDto lastLapTime { get; set; }
        public Dictionary<string, TimeDto?> currentLapSectorTimes { get; set; }
    }
}
