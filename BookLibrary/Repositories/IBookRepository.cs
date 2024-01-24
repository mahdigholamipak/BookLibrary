using BookLibrary.Models;
using System.Linq.Expressions;

namespace BookLibrary.Repositories
{
    public interface IBookRepository:IRepository<Book>
    {
        public Book GetBook(int Id);
         public Task<Book> GetBookAsync(int Id);
        public ICollection<Book> GetAllBooks();
        public Task<ICollection<Book>> GetAllBooksAsync();
        public ICollection<Book> FindBooks(Expression<Func<Book, bool>> predicate);
         public Task<ICollection<Book>> FindBooksAsync(Expression<Func<Book, bool>> predicate);

        public void AddBook(Book book);
        public Task AddBookAsync(Book book);
        public void UpdateBook(Book book);
        public void RemoveBook(Book book);
    }
}
