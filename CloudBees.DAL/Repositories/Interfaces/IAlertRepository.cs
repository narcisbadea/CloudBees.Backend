using CloudBees.DAL.Entities;

namespace CloudBees.DAL.Repositories.Interfaces
{
    public interface IAlertRepository
    {
        Task<IEnumerable<Alert>?> GetAllAlerts();
        Task<string> PostAlert(Alert alert);
    }
}