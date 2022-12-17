using CloudBees.DAL.Entitis;

namespace CloudBees.DAL.Repositories.Interfaces
{
    public interface IStatsRepository
    {
        Task<IEnumerable<AlertsStats>> GetAllAlertsStatsAsync();
        Task<IEnumerable<UsersStats>> GetAllUserStats();
        Task<AlertsStats?> GetLastAlertsStats();
    }
}