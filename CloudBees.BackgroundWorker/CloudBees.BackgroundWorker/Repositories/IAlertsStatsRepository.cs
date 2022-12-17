namespace CloudBees.BackgroundWorker.Repositories
{
    public interface IAlertsStatsRepository
    {
        Task GenerateAlertsStats();
    }
}