using CloudBees.BLL.Services.Interfaces;
using CloudBees.DAL.Entities;
using CloudBees.DAL;
using CloudBees.DAL.Repositories.Interfaces;
using CloudBees.BLL.DTOs;
using AutoMapper;

namespace CloudBees.BLL.Services.Implementation;

public class AlertTypeService : IAlertTypeService
{
    private readonly IAlertTypeRepository _alertTypeRepository;
    private readonly IMapper _mapper;

    public AlertTypeService(IAlertTypeRepository alertTypeRepository, IMapper mapper)
    {
        _alertTypeRepository = alertTypeRepository;
        _mapper = mapper;
    }

    public async Task<string> GetAlertTypeByIdAsync(string alertTypeId)
    {
        var result = await _alertTypeRepository.GetTypeById(alertTypeId);
        return result.Type;
    }

    public async Task<IEnumerable<AlertTypeDTO>> GetAllAlertTypes()
    {
        var result = await _alertTypeRepository.GetAllAlertTypes();

        return _mapper.Map<IEnumerable<AlertType>, IEnumerable<AlertTypeDTO>>(result);
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
