using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BooksCatalog.Data.Entity;

namespace BooksCatalog.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(t => new { t.BookId, t.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(t => t.Book)
                .WithMany(t => t.BookAuthors)
                .HasForeignKey(t => t.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(t => t.Author)
                .WithMany(t => t.BookAuthors)
                .HasForeignKey(t => t.AuthorId);
        }
    }
}
