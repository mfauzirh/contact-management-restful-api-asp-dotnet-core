using ContactManagement.Models;

namespace ContactManagement.Repositories;

public interface IUserRepository
{
    Task<User?> GetAsync(string userName);
    Task<User> AddAsync(User user);
    Task<User> UpdateAsync(User user);
}