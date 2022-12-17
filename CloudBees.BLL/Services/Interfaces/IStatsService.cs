using CloudBees.BLL.DTOs;

namespace CloudBees.BLL.Services.Interfaces
{
    public interface IStatsService
    {
        Task<IEnumerable<AlertsStatsDTO>> GetAllAlertsStatsAsync();
        Task<IEnumerable<UserStatsDTO>> GetAllUserStatsAsync();
    }
}