using TslCompetencyTaskUi.Models.Dtos.Interfaces;

namespace TslCompetencyTaskUi.Models.Dtos
{
    public class TimeDto : ITimeDto
    {
        public string? display { get; set; }
        public int rawMs { get; set; }
    }
}
