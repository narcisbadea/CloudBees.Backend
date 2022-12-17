namespace CloudBees.BackgroundWorker.Repositories
{
    public interface IUsersStatsRepository
    {
        Task GenerateUsersStats();
    }
}