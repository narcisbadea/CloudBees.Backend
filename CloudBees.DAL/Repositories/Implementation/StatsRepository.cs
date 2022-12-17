﻿using CloudBees.DAL.Database;
using CloudBees.DAL.Entitis;
using CloudBees.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace CloudBees.DAL.Repositories.Implementation;

public class StatsRepository : IStatsRepository
{
    private readonly StatsDbContext _dbContext;

    public StatsRepository(StatsDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<IEnumerable<AlertsStats>> GetAllAlertsStatsAsync()
    {
        return await _dbContext.AlertsStats.ToListAsync();
    }

    public async Task<IEnumerable<UsersStats>> GetAllUserStats()
    {
        return await _dbContext.UsersStats.ToListAsync();
    }

    public async Task<AlertsStats?> GetLastAlertsStats()
    {
        return await _dbContext.AlertsStats.OrderByDescending(s => s.Date).FirstOrDefaultAsync();
    }
}
