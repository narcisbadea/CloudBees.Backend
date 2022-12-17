using CloudBees.BackgroundWorker.Entitis;
using CloudBees.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBees.BackgroundWorker.Database;

public class DataDbContext : IdentityDbContext<User, Role, string>
{
    private readonly IConfiguration _configuration;
    public DataDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("data"));
    }
    public DbSet<AlertType> AlertTypes { get; set; }
    public DbSet<Alert> Alerts { get; set; }
}
