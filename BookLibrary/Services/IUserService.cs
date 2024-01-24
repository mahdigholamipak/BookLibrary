using BookLibrary.Models;
using BookLibrary.Models.ViewModels;

namespace BookLibrary.Services
{
    public interface IUserService
    {
        public User GetUserModelFromRegisterViewModel(RegisterViewModel registerViewModel);
        public Task<User> GetUserModelFromRegisterViewModelAsync(RegisterViewModel registerViewModel);

        public User GetUserModelFromUserViewModel(UserViewModel userViewModel);
        public Task<User> GetUserModelFromUserViewModelAsync(UserViewModel userViewModel);

    }
}
