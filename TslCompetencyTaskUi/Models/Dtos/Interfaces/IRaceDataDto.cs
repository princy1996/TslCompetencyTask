using TslCompetencyTaskUi.Models.Enums;

namespace TslCompetencyTaskUi.Models.Dtos.Interfaces
{
    public interface IRaceDataDto
    {
        public string sessionId { get; set; }
        public string? series { get; set; }
        public string? track { get; set; }
        public SessionState sessionState { get; set; }
        public string? startTime { get; set; }
        public string? duration { get; set; }
        public string? timeRemaining { get; set; }
        public List<CompetitorDto>? classification { get; set; }
    }
}
