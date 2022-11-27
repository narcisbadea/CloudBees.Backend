using CloudBees.DAL.Entities;

namespace CloudBees.BLL.Services.Interfaces
{
    public interface IAlertTypeService
    {
        Task<string> DeletAlertType(string id);
        Task<string> GetAlertTypeByIdAsync(string alertTypeId);
        Task<IEnumerable<AlertType>> GetAllAlertTypes();
        Task<string> PostAlertType(string type);
    }
}