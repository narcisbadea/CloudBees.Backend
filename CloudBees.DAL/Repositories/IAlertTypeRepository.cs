using CloudBees.DAL.Entities;

namespace CloudBees.DAL.Repositories
{
    public interface IAlertTypeRepository
    {
        Task<AlertType?> GetTypeById(string alertTypeId);
    }
}