using CloudBees.BLL.DTOs;
using CloudBees.DAL.Entities;

namespace CloudBees.BLL.Services
{
    public interface IAlertService
    {
        Task<IEnumerable<AlertDTO>?> GetAll();
        Task<string> PostAlert(AlertRequestDTO alert, User user);
    }
}