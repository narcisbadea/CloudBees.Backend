using CloudBees.DAL.Entities;

namespace CloudBees.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<string> CreateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetTrakedUserByIdAsync(string userId);
        Task<User?> GetUserByIdAsync(string userId);
        Task<User?> GetUserByName(string userName);
    }
}