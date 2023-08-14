using System;
using System.Collections.Generic;

namespace Avito_Console.Models;

/// <summary>
/// Объявления
/// </summary>
public partial class Advert
{
    public long Id { get; set; }

    public string Label { get; set; } = null!;

    public string Text { get; set; } = null!;

    public decimal Price { get; set; }

    public long User { get; set; }

    public long Category { get; set; }

    public virtual Category CategoryNavigation { get; set; } = null!;

    public virtual User UserNavigation { get; set; } = null!;

    public override string ToString()
    {
        return $"Id: {Id}\nЗаголовок: {Label}\nЦена: {Price}\nТекст: {Text}";
    }
}
