using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumerals.V2
{
    public class Convertor
    {
        public static int CalculateValue(string numeral)
        {
            switch (numeral)
            {
                case "I": return 1;
                case "V": return 5;
                case "X": return 10;
                case "L": return 50;
                case "C": return 100;
            }
            return 0;
        }
    }
}
