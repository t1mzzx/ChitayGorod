using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ChitayGorod.Models;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookLoan> BookLoans { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<LibraryUser> LibraryUsers { get; set; }

    public virtual DbSet<LoanStatus> LoanStatuses { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=library;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("pk_authors");

            entity.ToTable("authors", tb => tb.HasComment("Авторы книг"));

            entity.HasIndex(e => e.AuthorName, "uq_authors_name").IsUnique();

            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(150)
                .HasColumnName("author_name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("pk_books");

            entity.ToTable("books", tb => tb.HasComment("Каталог книг: количество экземпляров, аннотация, обложка"));

            entity.HasIndex(e => e.AuthorId, "ix_books_author_id");

            entity.HasIndex(e => e.GenreId, "ix_books_genre_id");

            entity.HasIndex(e => e.PublisherId, "ix_books_publisher_id");

            entity.HasIndex(e => e.Isbn, "uq_books_isbn").IsUnique();

            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.Annotation).HasColumnName("annotation");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.AvailableCopies).HasColumnName("available_copies");
            entity.Property(e => e.CoverImage)
                .HasMaxLength(255)
                .HasColumnName("cover_image");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .HasColumnName("isbn");
            entity.Property(e => e.Pages).HasColumnName("pages");
            entity.Property(e => e.PublicationYear).HasColumnName("publication_year");
            entity.Property(e => e.PublisherId).HasColumnName("publisher_id");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
            entity.Property(e => e.TotalCopies).HasColumnName("total_copies");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_books_author");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_books_genre");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Books)
                .HasForeignKey(d => d.PublisherId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_books_publisher");
        });

        modelBuilder.Entity<BookLoan>(entity =>
        {
            entity.HasKey(e => e.LoanId).HasName("pk_book_loans");

            entity.ToTable("book_loans", tb => tb.HasComment("Выдачи книг читателям: даты выдачи и возврата, статус"));

            entity.HasIndex(e => e.BookId, "ix_book_loans_book_id");

            entity.HasIndex(e => e.LoanStatusId, "ix_book_loans_status_id");

            entity.HasIndex(e => e.UserId, "ix_book_loans_user_id");

            entity.Property(e => e.LoanId).HasColumnName("loan_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.LoanDate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("loan_date");
            entity.Property(e => e.LoanStatusId).HasColumnName("loan_status_id");
            entity.Property(e => e.ReturnDate).HasColumnName("return_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Book).WithMany(p => p.BookLoans)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_book_loans_book");

            entity.HasOne(d => d.LoanStatus).WithMany(p => p.BookLoans)
                .HasForeignKey(d => d.LoanStatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_book_loans_status");

            entity.HasOne(d => d.User).WithMany(p => p.BookLoans)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_book_loans_user");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("pk_genres");

            entity.ToTable("genres", tb => tb.HasComment("Жанры книг"));

            entity.HasIndex(e => e.GenreName, "uq_genres_name").IsUnique();

            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.GenreName)
                .HasMaxLength(50)
                .HasColumnName("genre_name");
        });

        modelBuilder.Entity<LibraryUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_library_users");

            entity.ToTable("library_users", tb => tb.HasComment("Пользователи системы (вход по логину), читательский билет"));

            entity.HasIndex(e => e.RoleId, "ix_library_users_role_id");

            entity.HasIndex(e => e.LibraryCardNumber, "uq_library_users_card").IsUnique();

            entity.HasIndex(e => e.Login, "uq_library_users_login").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.LibraryCardNumber)
                .HasMaxLength(20)
                .HasColumnName("library_card_number");
            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .HasColumnName("login");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.LibraryUsers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_library_users_role");
        });

        modelBuilder.Entity<LoanStatus>(entity =>
        {
            entity.HasKey(e => e.LoanStatusId).HasName("pk_loan_statuses");

            entity.ToTable("loan_statuses", tb => tb.HasComment("Статусы выдачи: На руках, Возвращена"));

            entity.HasIndex(e => e.StatusName, "uq_loan_statuses_name").IsUnique();

            entity.Property(e => e.LoanStatusId).HasColumnName("loan_status_id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(30)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.PublisherId).HasName("pk_publishers");

            entity.ToTable("publishers", tb => tb.HasComment("Издательства"));

            entity.HasIndex(e => e.PublisherName, "uq_publishers_name").IsUnique();

            entity.Property(e => e.PublisherId).HasColumnName("publisher_id");
            entity.Property(e => e.PublisherName)
                .HasMaxLength(100)
                .HasColumnName("publisher_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("pk_roles");

            entity.ToTable("roles", tb => tb.HasComment("Роли: Администратор, Библиотекарь, Читатель"));

            entity.HasIndex(e => e.RoleName, "uq_roles_name").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
