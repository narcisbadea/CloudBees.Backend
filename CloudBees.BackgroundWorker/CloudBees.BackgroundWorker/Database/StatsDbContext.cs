using CloudBees.BackgroundWorker.Entitis.Stats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBees.BackgroundWorker.Database;

public class StatsDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public StatsDbContext(IConfiguration configuration) : base()
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("stats"));
    }

    public DbSet<UsersStats> UsersStats { get; set; }
    public DbSet<AlertsStats> AlertsStats { get; set; }
}
