using CloudBees.Common.DTOs;
using CloudBees.DAL.Entities;

namespace CloudBees.DAL.Repositories.Interfaces
{
    public interface IAlertRepository
    {
        Task<bool> CloseAlertAsync(string alertId);
        Task<string> DeleteAlert(string id);
        Task<IEnumerable<Alert>?> GetAlertByFilters(FiltersAlert filters);
        Task<Alert?> GetAlertByIdAsync(string id);
        Task<IEnumerable<Alert>?> GetAllAlerts();
        Task<IEnumerable<Alert>?> GetAllAlertsForLoggedUser(string idUser);
        Task<string> PostAlert(Alert alert);
    }
}