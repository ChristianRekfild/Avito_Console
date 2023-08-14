using Avito_Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avito_Console.ResourceHelpers
{
    internal class CategoryHelper
    {
        public CategoryHelper(DataActions action)
        {
            switch (action)
            {
                case DataActions.Read:
                    PrintDataInTableCategory();
                    break;

                case DataActions.Write:
                    AddRecorsToTableCategory();
                    break;
            }
        }

        private void AddRecorsToTableCategory()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Выводит все данные из таблицы категории
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void PrintDataInTableCategory()
        {
            using (AvitoContext context = new AvitoContext())
            {
                foreach (Category category in context.Categories) 
                {
                    Console.WriteLine(category.ToString());
                }
            }
        }
    }
}
