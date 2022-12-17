using AutoMapper;
using CloudBees.BLL.DTOs;
using CloudBees.BLL.Services.Interfaces;
using CloudBees.DAL.Entitis;
using CloudBees.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBees.BLL.Services.Implementation;

public class StatsService : IStatsService
{
    private readonly IStatsRepository _statsRepository;
    private readonly IMapper _mapper;

    public StatsService(IStatsRepository statsRepository, IMapper mapper)
    {
        _statsRepository = statsRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AlertsStatsDTO>> GetAllAlertsStatsAsync()
    {
        var result = await _statsRepository.GetAllAlertsStatsAsync();
        if (result == null)
        {
            return new List<AlertsStatsDTO>();
        }
        return _mapper.Map<IEnumerable<AlertsStats>, IEnumerable<AlertsStatsDTO>>(result);
    }

    public async Task<IEnumerable<UserStatsDTO>> GetAllUserStatsAsync()
    {
        var result = await _statsRepository.GetAllUserStats();
        if (result == null)
        {
            return new List<UserStatsDTO>();
        }
        return _mapper.Map<IEnumerable<UsersStats>, IEnumerable<UserStatsDTO>>(result);
    }
}
