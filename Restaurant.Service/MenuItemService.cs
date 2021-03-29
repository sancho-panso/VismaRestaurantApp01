using Restaurant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service
{
    public class MenuItemService
    {
        private List<StockItem> _stockItem; 
        private List<MenuItem> _menuItem;

        public MenuItemService(List<StockItem> stockItem,
                                List<MenuItem> menuItems)
        {
            _stockItem = stockItem;
            _menuItem = menuItems;
        }
        public void CreateMenuItem()
        {
            int id = _menuItem.Count() + 1;
            Console.WriteLine("Please enter menu item Name:");
            string name = Console.ReadLine();

            List<int> products = ListOfId(new List<int>());

            MenuItem item = new MenuItem(id, name, products);
            _menuItem.Add(item);
        }

        public void DisplayMenuItems()
        {
            Console.WriteLine("*************CURRENT MENU ITEMS*************");
            foreach (MenuItem item in _menuItem)
            {
                item.PrintToConsole();
            }
            Console.WriteLine();
        }

        public void UpdateMenuItemName()
        {
            int id = ValidationService.InputValidInt("Please chose menu item ID:");
            MenuItem item = _menuItem.Where(i => i.ID == id).FirstOrDefault();
            if (item != null)
            {
                Console.WriteLine("Please enter new menu item Name:");
                string name = Console.ReadLine();
                item.Name = name;
            }
            else
            {
                Console.WriteLine("No such item in menu list");
            }
        }
        public void UpdateMenuItemProducts()
        {
            int id = ValidationService.InputValidInt("Please chose menu item ID:");
            MenuItem item = _menuItem.Where(i => i.ID == id).FirstOrDefault();
            if (item != null)
            {
                List<int> listOfProducts = ListOfId(item.StockItems);
                item.StockItems = listOfProducts;
            }
            else
            {
                Console.WriteLine("No such item in menu list");
            }
        }



        private List<int> ListOfId(List<int> idList)
        {
            string input = "";
            
            do
            {
                int id = ValidationService.InputValidInt("Please enter stock item ID:");
                
                if (_stockItem.Any(item => item.ID == id))
                {
                    if (!idList.Any(i => i == id))
                    {
                        idList.Add(id);
                    }
                    else
                    {
                        Console.WriteLine("Stock item already in Products list");
                    }
                }
                else
                {
                    Console.WriteLine("No item with required ID found in the stock list");
                }
                Console.WriteLine("Press Y for continue or any another button for escape");
                input = Console.ReadLine().ToLower();
            } while (input == "y");

            return idList;
        }


    }
}
