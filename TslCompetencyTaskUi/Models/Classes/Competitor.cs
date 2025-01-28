namespace TslCompetencyTaskUi.Models.Classes
{
    public class Competitor
    {
        public string Id { get; set; }
        public string? StartNumber { get; set; }
        public string? Name { get; set; }
        public string? TeamName { get; set; }
        public string? ClassName { get; set; }
        public int? Position { get; set; }
        public bool Finished { get; set; }
        public int Laps { get; set; }
        public Time FastestLapTime { get; set; }
        public Time LastLapTime { get; set; }
        public Dictionary<string, Time?> CurrentLapSectorTimes { get; set; }
    }
}
