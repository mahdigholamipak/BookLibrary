using BookLibrary.Models;
using BookLibrary.Models.ViewModels;

namespace BookLibrary.Services
{
    public interface IBookService
    {
        public Book GetBookModelFromViewModel(BookViewModel bookViewModel);

        public Task<Book> GetBookModelFromViewModelAsync(BookViewModel bookViewModel);

        public BookViewModel GetBookViewModelFromModel(Book bookModel);
        public Task<BookViewModel> GetBookViewModelFromModelAsync(Book bookModel);

        public ICollection<BookViewModel> GetBookViewModelsFromModels(ICollection<Book> bookModels);
        public Task<ICollection<BookViewModel>> GetBookViewModelsFromModelsAsync(ICollection<Book> bookModels);
    }
}
