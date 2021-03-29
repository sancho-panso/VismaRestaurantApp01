using Restaurant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service
{
    public class OrderItemService
    {
        private List<StockItem> _stockItem;
        private List<MenuItem> _menuItem;
        private List<OrderItem> _orderItem;
        public OrderItemService(List<StockItem> stockItem,
                                List<MenuItem> menuItems,
                                List<OrderItem> orderItems)
        {
            _stockItem = stockItem;
            _menuItem = menuItems;
            _orderItem = orderItems;
        }

        public void PlaceNewOrder()
        {
            int id = _orderItem.Count() + 1;
            List<int> orderedMenuItems = ListOfMenuId();
            if(orderedMenuItems.Count() > 0)
            {
                OrderItem order = new OrderItem(id, orderedMenuItems);
                _orderItem.Add(order);
            }
        }

        public void DisplayOrderList()
        {
            Console.WriteLine("*************CURRENT ORDER LIST*************");
            foreach (OrderItem item in _orderItem)
            {
                item.PrintToConsole();
            }
        }


        private List<int> ListOfMenuId()
        {
            string input = "";
            List<int> orderedMenuItems = new List<int>();

            do
            {
                int id = ValidationService.InputValidInt("Please enter menu item ID to start new order:");

                MenuItem menuItem = _menuItem.Where(item => item.ID == id).FirstOrDefault();
                if (menuItem != null)
                {
                    bool stockEnough = true;
                    List<int> ingredientsIDs = menuItem.StockItems;
                    foreach(int ingID in ingredientsIDs)
                    {
                        StockItem stockItem =_stockItem.Where(s => s.ID == ingID).FirstOrDefault();
                        if(stockItem.PortionCount-1 >= 0)
                        {
                            stockItem.PortionCount -= 1;
                        }
                        else
                        {
                            stockEnough = false;
                            Console.WriteLine("Not enough items in stock to deliver your ordered dish");
                            break;
                        }
                    }
                    if (stockEnough)
                    {
                        orderedMenuItems.Add(menuItem.ID);
                        Console.WriteLine("Menu item is added to your order");
                    }                
                }
                else
                {
                    Console.WriteLine("No item with required ID found in the menu list");
                }
                Console.WriteLine("Press Y for continue or any another button for escape");
                input = Console.ReadLine().ToLower();
            } while (input == "y");

            return orderedMenuItems;
            
        }
    }
}
