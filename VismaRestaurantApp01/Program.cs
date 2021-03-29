using Restaurant.Entities;
using Restaurant.Service;
using System;
using System.Collections.Generic;

namespace VismaRestaurantApp01
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService dataService = new DataService();
            List<StockItem> stock = dataService.GetStock();
            List<MenuItem> menu = dataService.GetMenu();
            List<OrderItem> orders = dataService.GetOrders();

            StockItemService stockService = new StockItemService(stock);
            MenuItemService menuService = new MenuItemService(stock, menu);
            OrderItemService orderService = new OrderItemService(stock, menu, orders);

            //stockService.CreateStockItem();
            stockService.UpdateStockItem();
            //stockService.RemoveStockItem();
            stockService.DisplayStockItems();
            //dataService.SaveStock(stock);

            //menuService.CreateMenuItem();
            menuService.DisplayMenuItems();
            //menuService.UpdateMenuItemProducts();
            //menuService.UpdateMenuItemName();
            //dataService.SaveMenu(menu);

            orderService.PlaceNewOrder();
            stockService.DisplayStockItems();
            orderService.DisplayOrderList();
            dataService.SaveStock(stock);
            dataService.SaveOrders(orders);

        }
    }
}
