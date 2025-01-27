using TslApi.DTOs.Enums;
using TslApi.DTOs.Models;

namespace TslApi.DTOs.Interface
{
    public interface IRaceDataDto
    {
        string sessionId { get; set; }
        string? series { get; set; }
        string? track { get; set; }
        SessionState sessionState { get; set; }
        string? startTime { get; set; }
        string? duration { get; set; }
        string? timeRemaining { get; set; }
        List<CompetitorDto>? classification { get; set; }
    }
}
