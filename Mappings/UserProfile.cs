using AutoMapper;
using Task.Models;
using Task.Models.ViewModels;

namespace Task.Mappings
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserVm>().ReverseMap();
        }
    }
}