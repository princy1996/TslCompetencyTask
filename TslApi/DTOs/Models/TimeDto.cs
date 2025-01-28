using TslApi.DTOs.Interface;

namespace TslApi.DTOs.Models
{
    public class TimeDto : ITimeDto
    {
        public string? display { get; set; }
        public int rawMs { get; set; }
    }
}
