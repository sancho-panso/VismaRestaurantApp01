using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entities
{
    public class OrderItem
    {
        public int ID { get; set; }
        public string Date_Time { get; set; }
        public List<int> MenuItems { get; set; }

        public OrderItem(int id, List<int> menuItems)
        {
            ID = id;
            MenuItems = menuItems;
            Date_Time = DateTime.Now.ToString("u");
        }
        public OrderItem(string param)
        {
            string[] paramArray = param.Split(',');
            ID = Int32.Parse(paramArray[0]);
            Date_Time = paramArray[1];
            MenuItems = Helper.StringToList(paramArray[2]);
        }

        public override string ToString()
        {
            return ID.ToString() + "," + Date_Time + "," + Helper.ListToString(MenuItems);
        }

        public void PrintToConsole()
        {
            Console.WriteLine("ID: " + ID.ToString() + ","
                            + "Date Time: " + Date_Time + ","
                            + "Menu Items: " + Helper.ListToString(MenuItems));

        }
    }
}
