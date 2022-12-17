using CloudBees.Common.DTOs;
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
            .Include(a => a.User)
            .Include(a => a.Type)
            .Where(a => a.Status != "Closed")
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Alert>?> GetAllAlertsForLoggedUser(string idUser)
    {
        return await _dbcontrext.Alerts
            .Include(a => a.Type)
            .Include(a => a.User)
            .Where(a => a.User.Id == idUser)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<string> PostAlert(Alert alert)
    {
        var alertExist = await _dbcontrext.Alerts
            .Include(a => a.Type)
            .Where(a => a.Location== alert.Location && a.Type.Type == alert.Type.Type)
            .ToListAsync();
        if (alertExist.Count > 0)
        {
            return "Error, alert alrady exist!";
        }
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

    public async Task<IEnumerable<Alert>?> GetAlertByFilters(FiltersAlert filters)
    {
        var alerts = _dbcontrext.Alerts
            .Include(a => a.User)
            .Include(a => a.Type)
            .Where(a => a.Status != "Closed")
            .AsQueryable();

        if (filters.Name != null)
        {
            alerts = alerts.Where(a => (a.User.FirstName + " " + a.User.LastName).ToUpper().Contains(filters.Name.ToUpper()));
        }
        if (filters.AlertTypeId != null)
        {
            alerts = alerts.Where(a => a.Type.Id == filters.AlertTypeId);
        }

        return await alerts.ToListAsync();
    }

    public async Task<bool> CloseAlertAsync(string alertId)
    {
        var alert = await GetAlertByIdAsync(alertId);
        if (alert == null)
        {
            return false;
        }
        alert.Status = "Closed";
        var result = await _dbcontrext.SaveChangesAsync();
        if(result == 0)
        {
            return false;
        }
        return true;
    }
}
