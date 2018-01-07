using System;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using Task.Models;
using Task.Models.RequestParams;
using Task.Models.ViewModels;
using Task.Repositories;

namespace Task.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserVm> RegisterUser(NewUserParams newUser)
        {
            var user = new User(newUser);
            var result = await _userRepository.SaveUser(user);
            return _mapper.Map<UserVm>(result);
        }

        public async Task<UserVm> Login(LoginParams loginParams)
        {
            var currentUser = await _userRepository.GetUserByUsername(loginParams.Username);

            if (currentUser == null)
            {
                throw new Exception("Check username or password");
            }

            if (loginParams.Password != currentUser.Password)
            {
                throw new Exception("Check username or password");
            }

            return _mapper.Map<UserVm>(currentUser);
        }

        public async Task<UserVm> Get(string username)
        {
            var result = await _userRepository.GetUserByUsername(username);
            return _mapper.Map<UserVm>(result);
        }

//        public async Task<UserVm> ChangePassword(string newPassword, User user)
//        {
//            
//        }
//
//        public async Task<UserVm> UpdateProfile(User user)
//        {
//            
//        }
    }
}