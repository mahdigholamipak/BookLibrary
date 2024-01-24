using AutoMapper;
using BookLibrary.Models;
using BookLibrary.Models.ViewModels;

namespace BookLibrary.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public User GetUserModelFromRegisterViewModel(RegisterViewModel registerViewModel)
        {
            User user = _mapper.Map<RegisterViewModel, User>(registerViewModel);
            return user;
        }

        public async Task<User> GetUserModelFromRegisterViewModelAsync(RegisterViewModel registerViewModel)
        {
            User user = _mapper.Map<RegisterViewModel, User>(registerViewModel);
            return user;
        }

        public User GetUserModelFromUserViewModel(UserViewModel userViewModel)
        {
            User userModel = _mapper.Map<UserViewModel, User>(userViewModel);
            return userModel;
        }

        public async Task<User> GetUserModelFromUserViewModelAsync(UserViewModel userViewModel)
        {
            User userModel = _mapper.Map<UserViewModel, User>(userViewModel);
            return userModel;
        }
    }
}
