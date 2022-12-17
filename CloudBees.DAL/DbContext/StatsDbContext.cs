using CloudBees.DAL.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace CloudBees.DAL.Database;

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
