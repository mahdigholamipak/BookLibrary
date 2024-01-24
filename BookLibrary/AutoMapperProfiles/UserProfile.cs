using AutoMapper;
using BookLibrary.Models;
using BookLibrary.Models.ViewModels;

namespace BookLibrary.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterViewModel, User>();


            CreateMap<UserViewModel, User>();

        }
    }
}
