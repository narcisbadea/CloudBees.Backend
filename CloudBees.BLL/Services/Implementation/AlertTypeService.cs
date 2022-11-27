using CloudBees.BLL.Services.Interfaces;
using CloudBees.DAL.Entities;
using CloudBees.DAL;
using CloudBees.DAL.Repositories.Interfaces;


namespace CloudBees.BLL.Services.Implementation;

public class AlertTypeService : IAlertTypeService
{
    private readonly IAlertTypeRepository _alertTypeRepository;

    public AlertTypeService(IAlertTypeRepository alertTypeRepository)
    {
        _alertTypeRepository = alertTypeRepository;
    }

    public async Task<string> GetAlertTypeByIdAsync(string alertTypeId)
    {
        var result = await _alertTypeRepository.GetTypeById(alertTypeId);
        return result.Type;
    }

    public async Task<IEnumerable<AlertType>> GetAllAlertTypes()
    {
        var result = await _alertTypeRepository.GetAllAlertTypes();
        return result;
    }

    public async Task<string> PostAlertType(string type)
    {
        var result = await _alertTypeRepository.PostAlertType(new AlertType { Id = Guid.NewGuid().ToString(), Type = type });
        return result;
    }

    public async Task<string> DeletAlertType(string id)
    {
        return await _alertTypeRepository.DeletAlertType(id);
    }
}
