using CloudBees.BackgroundWorker.Database;
using CloudBees.BackgroundWorker.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CloudBees.BackgroundWorker;

class Program
{
    static void BuildConfig(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIROMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables();
    }
    static async Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder();
        BuildConfig(builder);
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((contezt,services) =>
            {
                services.AddDbContext<StatsDbContext>();
                services.AddDbContext<DataDbContext>();
                services.AddTransient<IUsersStatsRepository, UsersStatsRepository>();
                services.AddTransient<IAlertsStatsRepository, AlertsStatsRepository>();
            }).Build();

        var _statsUsersRepository = ActivatorUtilities.CreateInstance<UsersStatsRepository>(host.Services);
        var _statsAlertsRepository = ActivatorUtilities.CreateInstance<AlertsStatsRepository>(host.Services);


        await _statsUsersRepository.GenerateUsersStats();
        await _statsAlertsRepository.GenerateAlertsStats();
    }
}
