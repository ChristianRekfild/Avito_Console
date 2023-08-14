using Avito_Console.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avito_Console.ResourceHelpers
{
    internal class UserHelper
    {
        public UserHelper(DataActions action) 
        {
            switch (action)
            {
                case DataActions.Read:
                    PrintDataInTableUser();
                    break;

                case DataActions.Write:
                    AddRecorsToTableUser();
                    break;
            }
        }

        private void AddRecorsToTableUser()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Вывод данных из таблицы пользователей
        /// </summary>
        private void PrintDataInTableUser()
        {
            using (AvitoContext context = new AvitoContext())
            {
                foreach (var user in context.Users)
                {
                    Console.WriteLine(user.ToString());
                }
            }
        }
    }
}
