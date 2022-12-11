using AutoMapper;
using CloudBees.BLL.DTOs;
using CloudBees.BLL.Services.Interfaces;
using CloudBees.Common.DTOs;
using CloudBees.DAL.Entities;
using CloudBees.DAL.Repositories.Interfaces;

namespace CloudBees.BLL.Services.Implementation;

public class AlertService : IAlertService
{
    private readonly IAlertRepository _alertRepository;
    private readonly IUserRepository _userRepository;
    private readonly IAlertTypeRepository _alertTypeRepository;
    private readonly IMapper _mapper;

    public AlertService(IAlertRepository alertRepository, IMapper mapper, IAlertTypeRepository alertTypeRepository)
    {
        _alertRepository = alertRepository;
        _mapper = mapper;
        _alertTypeRepository = alertTypeRepository;
    }

    public async Task<IEnumerable<AlertDTO>?> GetAll()
    {
        var result = await _alertRepository.GetAllAlerts();
        return _mapper.Map<IEnumerable<Alert>, IEnumerable<AlertDTO>>(result);
    }

    public async Task<IEnumerable<AlertDTO>?> GetAllAlertsForLoggedUserAsync( string userId)
    {
        var result = await _alertRepository.GetAllAlertsForLoggedUser(userId);
        return _mapper.Map<IEnumerable<Alert>, IEnumerable<AlertDTO>>(result);
    }

    public async Task<IEnumerable<AlertDTO>?> GetAlertByFilters(FiltersAlert filters)
    {
        var result = await _alertRepository.GetAlertByFilters(filters);
        if(result.Count() <= 0)
        {
            return null;
        }
        return _mapper.Map<IEnumerable<Alert>, IEnumerable<AlertDTO>>(result);
    }

    public async Task<string> PostAlert(AlertRequestDTO alert, User user)
    {
        var toAdd = _mapper.Map<Alert>(alert);
        toAdd.Id = Guid.NewGuid().ToString();
        toAdd.User = user;

        var alertType = await _alertTypeRepository.GetTypeById(alert.TypeId);
        toAdd.Type = alertType;

        var result = await _alertRepository.PostAlert(toAdd);
        return result;
    }

    public async Task<string> DeleteAlert(string id)
    {
        return await _alertRepository.DeleteAlert(id);
    }

    public async Task<AlertDTO?> GetAlertByIdAsync(string id)
    {
        var result = await _alertRepository.GetAlertByIdAsync(id);
        return _mapper.Map<AlertDTO>(result);
    }

    
}
