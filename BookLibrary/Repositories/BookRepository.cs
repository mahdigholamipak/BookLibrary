using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookLibrary.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext dbContext) : base(dbContext)
        {
        }

        public async Task AddBookAsync(Book book)
        {
            await Context.Set<Book>().AddAsync(book);
        }

        public async Task<ICollection<Book>> FindBooksAsync(Expression<Func<Book, bool>> predicate)
        {
            return await Context.Set<Book>().Where(predicate).Include(book => book.User).ToListAsync();
        }

        public async Task<ICollection<Book>> GetAllBooksAsync()
        {
            return await Context.Set<Book>().Include(book => book.User).ToListAsync();
        }

        public async Task<Book> GetBookAsync(int Id)
        {
            return await Context.Set<Book>().Include(book => book.User).FirstOrDefaultAsync(book => book.Id == Id);
        }


        void IBookRepository.AddBook(Book book)
        {
            Context.Set<Book>().Add(book);
        }


        ICollection<Book> IBookRepository.FindBooks(Expression<Func<Book, bool>> predicate)
        {
            return Context.Set<Book>().Where(predicate).Include(book => book.User).ToList();
        }


        ICollection<Book> IBookRepository.GetAllBooks()
        {
            return Context.Set<Book>().Include(book => book.User).ToList();
        }

        Book IBookRepository.GetBook(int Id)
        {

            return Context.Set<Book>().Include(book => book.User).FirstOrDefault(book => book.Id == Id);

        }

        void IBookRepository.RemoveBook(Book book)
        {
            Context.Set<Book>().Remove(book);
        }

        void IBookRepository.UpdateBook(Book book)
        {
            Context.Set<Book>().Update(book);
        }
    }
}
