using System;
using System.Collections.Generic;


namespace Restaurant.Entities
{
    public class MenuItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<int> StockItems { get; set; }

        public MenuItem(int id, string name, List<int> stockItems)
        {
            ID = id;
            Name = name;
            StockItems = stockItems;
        }

        // constructor parse input string to obect properties, this help on object creation from text file 
        public MenuItem(string param)
        {
            string[] paramArray = param.Split(',');
            ID = Int32.Parse(paramArray[0]);
            Name = paramArray[1];
            StockItems = Helper.StringToList(paramArray[2]);
        }

        public override string ToString()
        {
            return ID.ToString() + "," + Name + "," + Helper.ListToString(StockItems);
        }

        public void PrintToConsole()
        {
            Console.WriteLine("ID: " + ID.ToString() + ","
                            + "Name: " + Name + ","
                            + "Products: " + Helper.ListToString(StockItems));

        }


    }
}
