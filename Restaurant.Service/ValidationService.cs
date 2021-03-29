using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service
{
    public class ValidationService
    {
        public static int InputValidInt(string text)
        {
            while (true)
            {
                Console.Write(text);
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out int key))
                {
                    return key % 26;
                }
                else
                {
                    Console.WriteLine($"We can not convert input: '{input}' \nto an integer number, please try again");
                }
            }
        }
        public static double InputValidDouble(string text)
        {
            while (true)
            {
                Console.Write(text);
                string input = Console.ReadLine();
                if (Double.TryParse(input, out double key))
                {
                    return key;
                }
                else
                {
                    Console.WriteLine($"We can not convert input: '{input}' \nto a double number, please try again");
                }
            }
        }

        
    }
}
