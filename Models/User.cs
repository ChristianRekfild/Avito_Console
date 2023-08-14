using System;
using System.Collections.Generic;

namespace Avito_Console.Models;

/// <summary>
/// Пользователи приложения
/// </summary>
public partial class User
{
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly DateOfBirht { get; set; }

    public string Phone { get; set; } = null!;

    public virtual ICollection<Advert> Adverts { get; set; } = new List<Advert>();

    public override string ToString()
    {
        return $"{Id} {FirstName} {LastName}\t{DateOfBirht}\t{Phone}";
    }
}
