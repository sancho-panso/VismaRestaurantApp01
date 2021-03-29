using Restaurant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Restaurant.Service
{
    public class DataService
    {
        //helper methods to get restaurant's items data from and save back to .txt files
        public List<StockItem> GetStock()
        {
            List<StockItem> stock = new List<StockItem>();
            bool exists = System.IO.File.Exists(
            System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StockItems.txt"));
            if (exists)
            {
                string[] input = System.IO.File.ReadAllLines(
                System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StockItems.txt"));
                stock = input.Select(line => new StockItem(line)).ToList();
            }

            return stock;
        }

        public void SaveStock(List<StockItem> stock)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (var item in stock)
            {
                sb.AppendLine(item.ToString());
            }
            System.IO.File.WriteAllText(
                System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "StockItems.txt"),
                sb.ToString());
        } 
        public List<MenuItem> GetMenu()
        {
            List<MenuItem> menu = new List<MenuItem>();
            bool exists = System.IO.File.Exists(
            System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MenuItems.txt"));
            if (exists)
            {
                string[] input = System.IO.File.ReadAllLines(
                System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MenuItems.txt"));
                menu = input.Select(line => new MenuItem(line)).ToList();
            }

            return menu;
        }

        public void SaveMenu(List<MenuItem> menu)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (var item in menu)
            {
                sb.AppendLine(item.ToString());
            }
            System.IO.File.WriteAllText(
                System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "MenuItems.txt"),
                sb.ToString());
        }        
        
        public List<OrderItem> GetOrders()
        {
            List<OrderItem> orders = new List<OrderItem>();
            bool exists = System.IO.File.Exists(
            System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Orders.txt"));

            if (exists)
            {
                string[] input = System.IO.File.ReadAllLines(
                System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Orders.txt"));
                orders = input.Select(line => new OrderItem(line)).ToList();
            }

            return orders;
        }

        public void SaveOrders(List<OrderItem> orders)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (var item in orders)
            {
                sb.AppendLine(item.ToString());
            }
            System.IO.File.WriteAllText(
                System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "Orders.txt"),
                sb.ToString());
        }
    }
}
