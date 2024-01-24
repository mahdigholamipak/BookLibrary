namespace BookLibrary.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IBookRepository Books { get; }
        public int Complete();
        public Task CompleteAsync();
    }
}
