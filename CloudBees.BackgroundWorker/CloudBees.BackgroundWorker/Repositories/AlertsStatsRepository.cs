using CloudBees.BackgroundWorker.Database;
using CloudBees.BackgroundWorker.Entitis.Stats;
using Microsoft.EntityFrameworkCore;

namespace CloudBees.BackgroundWorker.Repositories;

public class AlertsStatsRepository : IAlertsStatsRepository
{
    private readonly StatsDbContext _contextStats;
    private readonly DataDbContext _contextData;

    public AlertsStatsRepository(StatsDbContext contextStats, DataDbContext contextData)
    {
        _contextStats = contextStats;
        _contextData = contextData;
    }

    public async Task GenerateAlertsStats()
    {
        var opened = await _contextData.Alerts.Where(a => a.Status == "Opened").CountAsync();
        var closed = await _contextData.Alerts.Where(a => a.Status == "Closed").CountAsync();

        _contextStats.AlertsStats.Add(new AlertsStats
        {
            Id = Guid.NewGuid().ToString(),
            OpenedAlerts = opened,
            ClosedALerts = closed,
            Date = DateTime.UtcNow
        });
        await _contextStats.SaveChangesAsync();
    }

}
