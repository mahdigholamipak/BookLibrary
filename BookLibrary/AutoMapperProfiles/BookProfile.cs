using AutoMapper;
using BookLibrary.Models;
using BookLibrary.Models.ViewModels;

namespace BookLibrary.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookViewModel>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));

            CreateMap<BookViewModel, Book>();


        }
    }
}
