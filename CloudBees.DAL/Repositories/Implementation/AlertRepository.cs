using CloudBees.DAL.Entities;
using CloudBees.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CloudBees.DAL.Repositories.Implementation;

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
        if (result.State == EntityState.Added)
        {
            await _dbcontrext.SaveChangesAsync();
            return "Added";
        }
        return "Error";
    }

    public async Task<string> DeleteAlert(string id)
    {
        var entity = await _dbcontrext.Alerts.FirstOrDefaultAsync(a => a.Id == id);
        var result = _dbcontrext.Alerts.Remove(entity);
        if(result.State == EntityState.Deleted)
        {
            await _dbcontrext.SaveChangesAsync();
            return "Deleted";
        }
        return "Error";
    }

    public async Task<Alert?> GetAlertByIdAsync(string id)
    {
        var result = await _dbcontrext.Alerts
            .Include(a => a.Type)
            .FirstOrDefaultAsync(a => a.Id == id);
        return result;
    }
}
