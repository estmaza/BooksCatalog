using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BooksCatalog.Data;
using BooksCatalog.Data.Entity;

namespace BooksCatalog.Data.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BooksCatalog.Data.Entity.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .HasMaxLength(256);

                    b.Property<string>("SecondName")
                        .HasMaxLength(256);

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BooksCatalog.Data.Entity.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MyEnum");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Pages");

                    b.Property<int>("Rating");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BooksCatalog.Data.Entity.BookAuthor", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("AuthorId");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookAuthor");
                });

            modelBuilder.Entity("BooksCatalog.Data.Entity.BookAuthor", b =>
                {
                    b.HasOne("BooksCatalog.Data.Entity.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BooksCatalog.Data.Entity.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
