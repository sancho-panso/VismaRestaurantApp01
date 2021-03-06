using System;


namespace Restaurant.Entities
{
    public enum Units
    {
        kg, litre, bottle, bag, piece, carton
    }
    public class StockItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PortionCount { get; set; }
        public double PortionSize { get; set; }
        public Units Unit { get; set; }

        public StockItem(string name, double size, Units unit)
        {
            Name = name;
            PortionSize = size;
            Unit = unit;
        }
        // constructor parse input string to obect properties, this help on object creation from text file 
        public StockItem(string param)
        {
            string[] paramArray = param.Split(',');
            ID = Int32.Parse(paramArray[0]);
            Name = paramArray[1];
            PortionCount = Int32.Parse(paramArray[2]);
            PortionSize = Double.Parse(paramArray[4]); ;
            Unit = (Units)Enum.Parse(typeof(Units), paramArray[3]);
        }

        public override string ToString()
        {
            return ID.ToString() + "," + Name + "," + PortionCount.ToString() + "," + Unit.ToString() + "," + PortionSize.ToString();
        }

        public void PrintToConsole()
        {
            Console.WriteLine("ID: " + ID.ToString() + ","
                            + "Name: "  + Name + ","
                            + "Portion Count: " + PortionCount.ToString() + ","
                            + "Unit: " + Unit.ToString() + ","
                            + "Portion Size: " + PortionSize.ToString());
        }
    }
}
