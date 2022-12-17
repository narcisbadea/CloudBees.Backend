using CloudBees.BLL.DTOs;
using CloudBees.DAL.Entitis;

namespace CloudBees.BLL.Services.Interfaces
{
    public interface IStatsService
    {
        Task<IEnumerable<AlertsStatsDTO>> GetAllAlertsStatsAsync();
        Task<IEnumerable<UserStatsDTO>> GetAllUserStatsAsync();
        Task<AlertsStatsDTO?> GetLastAlertsStats();
    }
}