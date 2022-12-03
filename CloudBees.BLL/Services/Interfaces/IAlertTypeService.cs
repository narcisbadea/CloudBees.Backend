using CloudBees.BLL.DTOs;
using CloudBees.DAL.Entities;

namespace CloudBees.BLL.Services.Interfaces;

public interface IAlertTypeService
{
    Task<string> DeletAlertType(string id);
    Task<string> GetAlertTypeByIdAsync(string alertTypeId);
    Task<IEnumerable<AlertTypeDTO>> GetAllAlertTypes();
    Task<string> PostAlertType(string type);
}