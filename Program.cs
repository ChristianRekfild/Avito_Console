using Avito_Console.ResourceHelpers;
using Microsoft.EntityFrameworkCore;


Console.WriteLine("Добро пожаловать на новый минималистичный интейфейс авито!");
Console.WriteLine("Теперь пользоваться нашим приложением можно даже через умную микроволновку! =)");

string input = string.Empty;
while(input != "выход")
{
    Console.WriteLine("\nВыберите таблицу для просмотра:" +
    "\n1 - Пользователи" +
    "\n2 - Категории" +
    "\n3 - Объявления"
    );

    Console.WriteLine("Введите выход для того, чтобы попрощаться с нами!");

    input = Console.ReadLine().ToLower();

    if (input == "выход") break;

    if (!int.TryParse(input, out _))
    {
        Console.WriteLine("Ошибка ввода.");
        continue;
    }

    TableDataHelper helper = new TableDataHelper((EnumActions)int.Parse(input));

}

Console.WriteLine("Пока! Ждём вас снова!\nВ следующей версии шрифты будут разного цвета, так как мы наконец начнём платить нашим дизайнерам!");