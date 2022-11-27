using CloudBees.DAL.Entities;

namespace CloudBees.DAL.Repositories.Interfaces
{
    public interface IAlertTypeRepository
    {
        Task<string> DeletAlertType(string id);
        Task<IEnumerable<AlertType>> GetAllAlertTypes();
        Task<AlertType?> GetTypeById(string alertTypeId);
        Task<string> PostAlertType(AlertType type);
    }
}