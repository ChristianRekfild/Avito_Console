using Avito_Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avito_Console.ResourceHelpers
{
    internal class AdvertHelper
    {
        public AdvertHelper(DataActions action)
        {
            switch (action)
            {
                case DataActions.Read:
                    PrintDataInTableAdvert();
                    break;

                case DataActions.Write:
                    AddRecorsToTableAdvert();
                    break;
            }
        }

        private void AddRecorsToTableAdvert()
        {
            throw new NotImplementedException();
        }

        private void PrintDataInTableAdvert()
        {
            using (AvitoContext contex = new AvitoContext())
            {
                foreach (Advert advert in contex.Adverts)
                {
                    User user;
                    Category category;

                    using (AvitoContext innerContext = new AvitoContext())
                    {
                        user = innerContext.Users.SingleOrDefault(x => x.Id == advert.User);
                        category = innerContext.Categories.SingleOrDefault(x => x.Id == advert.Category);
                    }
                    

                    Console.WriteLine($"Пользователь: {user.ToString()}");
                    Console.WriteLine($"Категория: {category.ToString()}");
                    Console.WriteLine($"{advert.ToString()}\n");
                }
            }
        }
    }
}
