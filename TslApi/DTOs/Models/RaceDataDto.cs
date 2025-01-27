using TslApi.DTOs.Enums;
using TslApi.DTOs.Interface;

namespace TslApi.DTOs.Models
{
    public class RaceDataDto : IRaceDataDto
    {
        public required string sessionId { get; set; }
        public string? series { get; set; }
        public string? track { get; set; }
        public SessionState sessionState { get; set; }
        public string? startTime { get; set; }
        public string? duration { get; set; }
        public string? timeRemaining { get; set; }
        public List<CompetitorDto>? classification { get; set; }
    }
}
