using Restaurant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Service
{
    // method for work with collection of stock's items: create stock item, update stock item, remove stock item, display list of stock items
    public class StockItemService
    {
        private List<StockItem> _stockItem;

        public StockItemService(List<StockItem> stockItem)
        {
            _stockItem = stockItem;
        }

        public void CreateStockItem()
        {
            int id = _stockItem.Count() + 1;
            Console.WriteLine("Please enter new stock item Name:");
            string name = Console.ReadLine();

            double size = ValidationService.InputValidDouble("Please enter stock item portion size:");

            Units unit = ValidationService.InputValidEnum();
            
            StockItem item = new StockItem(name, size, unit);
            item.ID = id;
            Console.WriteLine("New item was created");
            item.PrintToConsole();
            _stockItem.Add(item);

        } 
        public void UpdateStockItem()
        {
            int id = ValidationService.InputValidInt("Please enter stock item ID to add it to stock:");
            StockItem item = _stockItem.Where(i => i.ID == id).FirstOrDefault();

            if(item != null)
            {
                int count = ValidationService.InputValidInt("Please enter stock item portion's count to add to stock:");
                item.PortionCount = item.PortionCount + count;
            }
            else
            {
                Console.WriteLine("No such item in stock");
            }
        }
        public void RemoveStockItem()
        {
            int id = ValidationService.InputValidInt("Please enter stock item ID to remove it from stock:");
            StockItem item = _stockItem.Where(i => i.ID == id).FirstOrDefault();
            if(item != null)
            {
                int count = ValidationService.InputValidInt("Please enter stock item portion's count to remove from stock:");
                if ((item.PortionCount - count) >= 0)
                {
                    item.PortionCount = item.PortionCount - count;
                }
                else
                {
                    Console.WriteLine("Not enough portion in stock to perform request");
                }

            }
            else
            {
                Console.WriteLine("No such item in stock");
            }
        }

        public void DisplayStockItems()
        {
            Console.WriteLine("*************CURRENT STOCK ITEMS*************");
            foreach(StockItem item in _stockItem)
            {
                item.PrintToConsole();
            }
            Console.WriteLine();
        }
    
    }
}
