using System;
using System.Collections.Generic;

namespace ChitayGorod.Models;

/// <summary>
/// Статусы выдачи: На руках, Возвращена
/// </summary>
public partial class LoanStatus
{
    public int LoanStatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>();
}
