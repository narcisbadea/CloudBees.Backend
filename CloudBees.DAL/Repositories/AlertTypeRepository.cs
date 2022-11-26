using CloudBees.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBees.DAL.Repositories;

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
}
