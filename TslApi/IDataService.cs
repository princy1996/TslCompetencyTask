using TslApi.DTOs.Interface;

namespace TslApi
{
    public interface IDataService
    {
        Task<IRaceDataDto?> GetRaceData();
    }
}
