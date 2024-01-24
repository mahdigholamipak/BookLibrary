using BookLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data
{
    public class LibraryContext : IdentityDbContext<User>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasOne(b => b.User).WithMany(u => u.Books).HasForeignKey(u => u.UserId);
            modelBuilder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
                b.ToTable("MyUserLogins");
            });


        }
    }
}
