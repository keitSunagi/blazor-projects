using BlzAPIGameStore.Backend.Models;

namespace BlzAPIGameStore.Backend.Data.Services
{
    public interface IUserService
    {
        Task<User?> GetUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserById(string idUser);
    }
}
