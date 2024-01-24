using BookLibrary.Data;

namespace BookLibrary.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private LibraryContext _context { get; set; }
        public UnitOfWork(LibraryContext dbContext)
        {
            _context = dbContext;
            Books = new BookRepository(_context);
        }
        public IBookRepository Books { get; private set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public Task CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
