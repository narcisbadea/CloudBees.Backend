using CloudBees.DAL.Entities;

namespace CloudBees.DAL.Repositories
{
    public interface IAlertRepository
    {
        Task<IEnumerable<Alert>?> GetAllAlerts();
        Task<string> PostAlert(Alert alert);
    }
}