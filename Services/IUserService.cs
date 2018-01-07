using System.Threading.Tasks;
using Task.Models;
using Task.Models.RequestParams;
using Task.Models.ViewModels;

namespace Task.Services
{
    public interface IUserService
    {
        Task<UserVm> RegisterUser(NewUserParams newUser);
        Task<UserVm> Login(LoginParams loginParams);
        Task<UserVm> Get(string username);
//        Task<UserVm> ChangePassword(string newPassword, User currentUser);
//        Task<UserVm> UpdateProfile(User updatedUser);
    }
}