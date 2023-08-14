using System;
using System.Collections.Generic;

namespace Avito_Console.Models;

/// <summary>
/// Категории товаров
/// </summary>
public partial class Category
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Advert> Adverts { get; set; } = new List<Advert>();

    public override string ToString()
    {
        return $"{Id} {Name}";
    }
}
