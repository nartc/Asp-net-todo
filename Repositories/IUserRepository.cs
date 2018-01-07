using System.Threading.Tasks;
using Task.Models;
using Task.Models.RequestParams;

namespace Task.Repositories
{
    public interface IUserRepository
    {
        Task<User> SaveUser(User newUser);
        Task<User> GetUserByUsername(string username);
        Task<User> UpdateUser(User updatedUser);
    }
}