using CloudBees.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CloudBees.DAL.Repositories;

public class AlertRepository : IAlertRepository
{
    private readonly AppDbContext _dbcontrext;

    public AlertRepository(AppDbContext dbcontrext)
    {
        _dbcontrext = dbcontrext;
    }

    public async Task<IEnumerable<Alert>?> GetAllAlerts()
    {
        return await _dbcontrext.Alerts
            .Include(a => a.Type)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<string> PostAlert(Alert alert)
    {
        var result = await _dbcontrext.AddAsync(alert);
        if(result.State == EntityState.Added)
        {
            await _dbcontrext.SaveChangesAsync();
            return "Added";
        }
        return "Error";
    }
}
