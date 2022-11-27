using CloudBees.DAL.Entities;
using CloudBees.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBees.DAL.Repositories.Implementation;

public class AlertTypeRepository : IAlertTypeRepository
{
    private readonly AppDbContext _appDbContext;

    public AlertTypeRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<AlertType?> GetTypeById(string alertTypeId)
    {
        var result = await _appDbContext.AlertTypes.FirstOrDefaultAsync(a => a.Id == alertTypeId);
        return result;
    }

    public async Task<IEnumerable<AlertType>> GetAllAlertTypes()
    {
        var result = await _appDbContext.AlertTypes.ToListAsync();
        return result;
    }

    public async Task<string> PostAlertType( AlertType type)
    {
        var result = await _appDbContext.AlertTypes.AddAsync(type);
        if(result.State == EntityState.Added)
        {
            await _appDbContext.SaveChangesAsync();
            return "Added";
        }
        return "Error";
    }
}
