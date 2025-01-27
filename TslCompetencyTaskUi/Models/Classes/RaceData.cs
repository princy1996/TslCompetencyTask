using TslCompetencyTaskUi.Models.Enums;

namespace TslCompetencyTaskUi.Models.Classes
{
    public class RaceData
    {
        public RaceData()
        {
        }

        public string SessionId { get; set; }
        public string? Series { get; set; }
        public string? Track { get; set; }
        public SessionState SessionState { get; set; }
        public string? StartTime { get; set; }
        public string? Duration { get; set; }
        public string? TimeRemaining { get; set; }
        public List<Competitor?> Classification { get; set; }
    }
}
