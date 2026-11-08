using System;
using System.Collections.Generic;

namespace ChitayGorod.Models;

/// <summary>
/// Пользователи системы (вход по логину), читательский билет
/// </summary>
public partial class LibraryUser
{
    public int UserId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string LibraryCardNumber { get; set; } = null!;

    public string Login { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();

    public virtual Role Role { get; set; } = null!;
}
