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

    public AppDbContext(IConfiguration configuration) : base()
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SQLserver"));
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        this.SeedRoles(builder);

    }
    public DbSet<AlertType> AlertTypes { get; set; }
    public DbSet<Alert> Alerts { get; set; }

    private void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<Role>().HasData(
            new Role() { Id = "9d22ff52-1a0d-4832-997f-27e57e68ec9e", Name = "User", NormalizedName = "USER" },
            new Role() { Id = "b1a678cf-d7a2-415a-9a8f-52d51e067e88", Name = "Admin", NormalizedName = "ADMIN" });
    }

}