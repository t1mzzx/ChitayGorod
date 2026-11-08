using System;
using System.Collections.Generic;

namespace ChitayGorod.Models;

/// <summary>
/// Каталог книг: количество экземпляров, аннотация, обложка
/// </summary>
public partial class Book
{
    public int BookId { get; set; }

    public string Isbn { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int AuthorId { get; set; }

    public int GenreId { get; set; }

    public int PublisherId { get; set; }

    public short PublicationYear { get; set; }

    public int Pages { get; set; }

    public int TotalCopies { get; set; }

    public int AvailableCopies { get; set; }

    public string? Annotation { get; set; }

    public string? CoverImage { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();

    public virtual Genre Genre { get; set; } = null!;

    public virtual Publisher Publisher { get; set; } = null!;
}
