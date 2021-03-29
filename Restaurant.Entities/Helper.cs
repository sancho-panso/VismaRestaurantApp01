using System;
using System.Collections.Generic;
using System.Text;


namespace Restaurant.Entities
{
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
