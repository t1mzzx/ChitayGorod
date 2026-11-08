using System;
using System.Collections.Generic;

namespace ChitayGorod.Models;

/// <summary>
/// Жанры книг
/// </summary>
public partial class Genre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
