using Restaurant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service
{
    // seeds initial data to txt files if none exists
    public class DataSeed
    {
        private readonly List<StockItem> stockItems = new List<StockItem>()
        {
            new StockItem("1,Chicken,1,kg,0.3"),
            new StockItem("2,Potatoes,3,kg,0.3"),
            new StockItem("3,Cabbage,1,kg,0.2"),
            new StockItem("4,Coca-cola,20,bottle,1"),
            new StockItem("5,Chesse,2,kg,0.1"),
            new StockItem("6,Apple,4,kg,0.5"),
            new StockItem("7,Beaf,0,kg,0.6"),
            new StockItem("8,Banana,10,kg,0.1")
        };
        
        private readonly List<MenuItem> menuItems = new List<MenuItem>()
        {
            new MenuItem("1,Apple&Banana salad,6 8 "),
            new MenuItem("2,Chicken with Fries,1 2 4 "),
            new MenuItem("3,Chesse&Cabbage,3 5"),
            new MenuItem("4,Beafstrogan,7 2 3 "),
        };
        
        private readonly List<OrderItem> orders = new List<OrderItem>()
        {
            new OrderItem("1,2021-03-29 10:48:47Z,2 2 "),
            new OrderItem("2,2021-03-29 10:57:36Z,2 "),
            new OrderItem("3,2021-03-29 11:05:58Z,3 3 3"),
        };

        DataService service = new DataService();
        public void SeedStockToFile()
        {
            bool exists = System.IO.File.Exists(
            System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StockItems.txt"));
            if (!exists)
            {
                service.SaveStock(stockItems);
            }
            
            exists = System.IO.File.Exists(
            System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MenuItems.txt"));
            if (!exists)
            {
                service.SaveMenu(menuItems);
            }
            
            exists = System.IO.File.Exists(
            System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Orders.txt"));
            if (!exists)
            {
                service.SaveOrders(orders);
            }
        }


    }
}
