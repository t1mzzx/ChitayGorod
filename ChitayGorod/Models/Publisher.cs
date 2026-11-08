using System;
using System.Collections.Generic;

namespace ChitayGorod.Models;

/// <summary>
/// Издательства
/// </summary>
public partial class Publisher
{
    public int PublisherId { get; set; }

    public string PublisherName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
