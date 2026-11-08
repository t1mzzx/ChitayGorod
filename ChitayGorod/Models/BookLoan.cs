using System;
using System.Collections.Generic;

namespace ChitayGorod.Models;

/// <summary>
/// Выдачи книг читателям: даты выдачи и возврата, статус
/// </summary>
public partial class BookLoan
{
    public int LoanId { get; set; }

    public int UserId { get; set; }

    public int BookId { get; set; }

    public DateOnly LoanDate { get; set; }

    public DateOnly DueDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public int LoanStatusId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual LoanStatus LoanStatus { get; set; } = null!;

    public virtual LibraryUser User { get; set; } = null!;
}
