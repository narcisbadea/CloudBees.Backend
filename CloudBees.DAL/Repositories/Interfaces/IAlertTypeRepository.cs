using CloudBees.DAL.Entities;

namespace CloudBees.DAL.Repositories.Interfaces
{
    public interface IAlertTypeRepository
    {
        Task<IEnumerable<AlertType>> GetAllAlertTypes();
        Task<AlertType?> GetTypeById(string alertTypeId);
        Task<string> PostAlertType(AlertType type);
    }
}