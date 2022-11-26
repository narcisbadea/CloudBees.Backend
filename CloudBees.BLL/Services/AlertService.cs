using AutoMapper;
using CloudBees.BLL.DTOs;
using CloudBees.DAL.Entities;
using CloudBees.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBees.BLL.Services;

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
}
