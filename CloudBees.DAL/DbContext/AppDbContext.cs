using CloudBees.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CloudBees.DAL;

public class AppDbContext : IdentityDbContext<User, Role, string>
{
    private readonly IConfiguration _configuration;

    public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }
    public DbSet<AlertType> AlertTypes { get; set; }
    public DbSet<Alert> Alerts { get; set; }

}