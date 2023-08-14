using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avito_Console.ResourceHelpers
{
    internal class TableDataHelper
    {
        private DataActions Action { get; set; }

        /// <summary>
        /// Принимает Enum нужной таблицы и позволяет пользователю работать далее с ней
        /// </summary>
        /// <param name="input"></param>
        public TableDataHelper(EnumActions input) 
        { 
            switch (input)
            {
                case EnumActions.Users:
                    AskUserReadDataOrWrite();
                    WorkWithUsers();
                    break;

                case EnumActions.Category:
                    AskUserReadDataOrWrite();
                    WorkWithCategory();
                    break;

                case EnumActions.Adverts:
                    AskUserReadDataOrWrite();
                    WorkWithAdverts();
                    break;
            }
        }

        /// <summary>
        /// Пользволяет пользователю указать - хочет ли он только читать данные или же добавлять
        /// </summary>
        private void AskUserReadDataOrWrite()
        {
            Console.WriteLine("Выберите вариант взаимодействия с таблицей:\n" +
                "1 - Чтение данных\n" +
                "2 - Добавление данных");

            string input = Console.ReadLine();
            if      (input == "1") Action = DataActions.Read;
            else if (input == "2") Action = DataActions.Write;
            else // ОщиПка!
            {
                Console.WriteLine("Введены неверные данные!");
                return;
            }
        }

        private void WorkWithAdverts()
        {
            AdvertHelper advertHelper = new AdvertHelper(Action);
        }

        private void WorkWithCategory()
        {
            CategoryHelper categoryHelper = new CategoryHelper(Action);
        }

        private void WorkWithUsers()
        {
            UserHelper userHelper = new UserHelper(Action);
        }

    }
  
}
