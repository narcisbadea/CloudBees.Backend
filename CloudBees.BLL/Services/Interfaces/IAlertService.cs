using CloudBees.BLL.DTOs;
using CloudBees.DAL.Entities;

namespace CloudBees.BLL.Services.Interfaces
{
    public interface IAlertService
    {
        Task<string> DeleteAlert(string id);
        Task<AlertDTO?> GetAlertByIdAsync(string id);
        Task<IEnumerable<AlertDTO>?> GetAll();
        Task<IEnumerable<AlertDTO>?> GetAllAlertsForLoggedUserAsync(string userId);
        Task<string> PostAlert(AlertRequestDTO alert, User user);
    }
}