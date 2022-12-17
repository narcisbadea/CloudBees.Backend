using CloudBees.BackgroundWorker.Database;
using CloudBees.BackgroundWorker.Entitis.Stats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CloudBees.BackgroundWorker.Repositories;

public class UsersStatsRepository : IUsersStatsRepository
{
    private readonly StatsDbContext _contextStats;
    private readonly DataDbContext _contextData;

    public UsersStatsRepository(StatsDbContext contextStats, DataDbContext contextData)
    {
        _contextStats = contextStats;
        _contextData = contextData;
    }

    public async Task GenerateUsersStats()
    {
        var numberOfUsers = await _contextData.Users.CountAsync();
        _contextStats.UsersStats.Add(new UsersStats
        {
            Id = Guid.NewGuid().ToString(),
            NumberOfUsers = numberOfUsers,
            Date = DateTime.UtcNow
        });
        await _contextStats.SaveChangesAsync();
    }
}
