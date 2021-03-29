using Restaurant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service
{
    public class ValidationService
    {

        //helper method for user console interface and validation of user input of int, double and enums
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

        public static Units InputValidEnum()
        {
            while (true)
            {
                Console.WriteLine("Please enter stock item units:\n" +
                    "0 for kg\n" +
                    "1 for litre\n" +
                    "2 for bootle\n" +
                    "3 for bag\n" +
                    "4 for piece\n" +
                    "5 for carton");
                string input = Console.ReadLine();
                if (Enum.TryParse(input, out Units outputEnum) && Enum.IsDefined(typeof(Units), outputEnum))
                {
                    return outputEnum;
                }
                else
                {
                    Console.WriteLine($"We can not convert input: '{input}' \nto an unit, please try again");
                }
            }
        }


    }
}
