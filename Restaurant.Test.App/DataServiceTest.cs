using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Entities;
using Restaurant.Service;
using System;
using System.Collections.Generic;

namespace Restaurant.Test.App
{
    [TestClass]
    public class DataServiceTest
    {
        DataService dataService = new DataService();
        List<StockItem> Stock { get =>dataService.GetStock();}
        List<MenuItem> Menu { get =>dataService.GetMenu();}
        List<OrderItem> Orders { get =>dataService.GetOrders();}

        [TestMethod]
        public void checkGetStock()
        {
            foreach(var item in Stock)
            {
                Assert.IsInstanceOfType(item, typeof(StockItem));
            }

        }
        [TestMethod]
        public void checkGetMenu()
        {
            foreach(var item in Menu)
            {
                Assert.IsInstanceOfType(item, typeof(MenuItem));
            }

        }        
        
        [TestMethod]
        public void checkGetOrders()
        {

            foreach(var item in Orders)
            {
                Assert.IsInstanceOfType(item, typeof(OrderItem));
            }

        } 
        [TestMethod]
        public void checkSaveStock()
        {
            dataService.SaveStock(Stock);

            bool exits = System.IO.File.Exists(
            System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StockItems.txt"));

            Assert.IsTrue(exits);
        } 
        [TestMethod]
        public void checkSaveMenu()
        {
            dataService.SaveMenu(Menu);

            bool exits = System.IO.File.Exists(
            System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MenuItems.txt"));

            Assert.IsTrue(exits);
        }
        [TestMethod]
        public void checkSaveOrders()
        {
            dataService.SaveOrders(Orders);

            bool exits = System.IO.File.Exists(
            System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Orders.txt"));

            Assert.IsTrue(exits);
        }
    }
}
