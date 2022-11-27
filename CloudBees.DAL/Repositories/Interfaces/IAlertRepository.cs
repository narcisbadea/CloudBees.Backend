using CloudBees.DAL.Entities;

namespace CloudBees.DAL.Repositories.Interfaces
{
    public interface IAlertRepository
    {
        Task<string> DeleteAlert(string id);
        Task<Alert?> GetAlertByIdAsync(string id);
        Task<IEnumerable<Alert>?> GetAllAlerts();
        Task<string> PostAlert(Alert alert);
    }
}