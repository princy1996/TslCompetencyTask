using TslCompetencyTaskUi.Models.Dtos.Interfaces;

namespace TslCompetencyTaskUi.Models.Dtos
{
    public class CompetitorDto : ICompetitorDto
    {
        public string id { get; set; }
        public string? startNumber { get; set; }
        public string? name { get; set; }
        public string? teamName { get; set; }
        public string? className { get; set; }
        public int? position { get; set; }
        public bool finished { get; set; }
        public int laps { get; set; }
        public TimeDto fastestLapTime { get; set; }
        public TimeDto lastLapTime { get; set; }
        public Dictionary<string, TimeDto>? currentLapSectorTimes { get; set; }
    }
}
