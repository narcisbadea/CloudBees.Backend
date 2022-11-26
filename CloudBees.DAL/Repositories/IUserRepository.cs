using CloudBees.DAL.Entities;

namespace CloudBees.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<string> CreateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<User> GetUserById(string userId);
        Task<User> GetUserByName(string name);
    }
}