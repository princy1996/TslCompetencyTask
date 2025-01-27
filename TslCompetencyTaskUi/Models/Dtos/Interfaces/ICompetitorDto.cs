namespace TslCompetencyTaskUi.Models.Dtos.Interfaces
{
    public interface ICompetitorDto
    {
        public string id { get; set; }
        public string? startNumber { get; set; }
        public string? name { get; set; }
        public string? teamName { get; set; }
        public string? className { get; set; }
        public int? position { get; set; }
        public bool finished { get; set; }
        public int laps { get; set; }
        public ITimeDto fastestLapTime { get; set; }
        public ITimeDto lastLapTime { get; set; }
        public Dictionary<string, ITimeDto>? currentLapSectorTimes { get; set; }
    }
}
