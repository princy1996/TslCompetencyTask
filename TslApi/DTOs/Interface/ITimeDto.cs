namespace TslApi.DTOs.Interface
{
    public interface ITimeDto
    {
        string? display { get; set; }
        int rawMs { get; set; }
    }
}
