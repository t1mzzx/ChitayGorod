using System;
using System.Collections.Generic;

namespace ChitayGorod.Models;

/// <summary>
/// Роли: Администратор, Библиотекарь, Читатель
/// </summary>
public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<LibraryUser> LibraryUsers { get; set; } = new List<LibraryUser>();
}
