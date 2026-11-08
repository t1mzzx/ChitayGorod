using System;
using System.Collections.Generic;

namespace ChitayGorod.Models;

/// <summary>
/// Авторы книг
/// </summary>
public partial class Author
{
    public int AuthorId { get; set; }

    public string AuthorName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
