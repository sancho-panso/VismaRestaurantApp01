using System;
using System.Collections.Generic;
using System.Text;


namespace Restaurant.Entities
{
    //helper methods to convert string to int colletion and back to string
    static class Helper
    {
        public static string ListToString(List<int> stock)
        {
            StringBuilder idsString = new StringBuilder();
            foreach (int id in stock)
            {
                idsString.Append(id).Append(" ");
            }

            return idsString.ToString();
        }

        public static List<int> StringToList(string param)
        {
            List<int> intList = new List<int>();
            string[] paramArray = param.Split(' ');
            foreach(string item in paramArray)
            {
                if(Int32.TryParse(item, out int id)){
                    intList.Add(id);
                }
               
            }

            return intList;
        }
    }
}
