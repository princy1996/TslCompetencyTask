using TslApi.DTOs.Models;

namespace TslApi.DTOs.Interface
{
    public interface ICompetitorDto
    {
        string id { get; set; }
        string? startNumber { get; set; }
        string? name { get; set; }
        string? teamName { get; set; }
        string? className { get; set; }
        int? position { get; set; }
        bool finished { get; set; }
        int laps { get; set; }
        TimeDto fastestLapTime { get; set; }
        TimeDto lastLapTime { get; set; }
        Dictionary<string, TimeDto>? currentLapSectorTimes { get; set; }
    }
}
