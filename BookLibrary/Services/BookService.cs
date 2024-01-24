using AutoMapper;
using BookLibrary.Models;
using BookLibrary.Models.ViewModels;

namespace BookLibrary.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        public BookService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Book GetBookModelFromViewModel(BookViewModel bookViewModel)
        {
            Book book = _mapper.Map<BookViewModel, Book>(bookViewModel);
            return book;
        }

        public async Task<Book> GetBookModelFromViewModelAsync(BookViewModel bookViewModel)
        {
            Book book = _mapper.Map<BookViewModel, Book>(bookViewModel);
            return book;
        }

        public BookViewModel GetBookViewModelFromModel(Book bookModel)
        {
            BookViewModel bookViewModel = _mapper.Map<Book, BookViewModel>(bookModel);
            return bookViewModel;
        }

        public async Task<BookViewModel> GetBookViewModelFromModelAsync(Book bookModel)
        {
            BookViewModel bookViewModel = _mapper.Map<Book, BookViewModel>(bookModel);
            return bookViewModel;
        }

        public ICollection<BookViewModel> GetBookViewModelsFromModels(ICollection<Book> bookModels)
        {
            ICollection<BookViewModel> bookViewModels = _mapper.Map<ICollection<Book>, ICollection<BookViewModel>>(bookModels);

            return bookViewModels;
        }

        public async Task<ICollection<BookViewModel>> GetBookViewModelsFromModelsAsync(ICollection<Book> bookModels)
        {
            ICollection<BookViewModel> bookViewModels = _mapper.Map<ICollection<Book>, ICollection<BookViewModel>>(bookModels);

            return bookViewModels;
        }
    }
}
