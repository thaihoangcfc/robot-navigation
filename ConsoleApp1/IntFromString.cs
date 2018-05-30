using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class IntFromString
    {
        private string stringToDivide;

        public IntFromString(string s)
        {
            stringToDivide = s;
        }

        public List<int> getIntFromString()
        {
            string[] numbers = Regex.Split(stringToDivide, @"\D+");

            List<int> listInt = new List<int>();

            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    int i = int.Parse(value);
                    listInt.Add(i);
                }
            }

            return listInt;
        }
    }
}
