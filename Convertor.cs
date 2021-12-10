using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumerals.V2
{
    public class Convertor
    {
        public static int CalculateValue(char numeral)
        {
            switch (numeral)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
            }
            return 0;
        }
        public static int Convert(string numerals)
            // an array is needed because we need to seperate the numerals in order to add them together.
        {
            char[] romanNum;
            romanNum = numerals.ToCharArray();
            int result = 0;

        // for loop that creates a value to product a result for each numeral entered.
            for (int i = 0; i < romanNum.Length; i++)
            {
                int value = CalculateValue(romanNum[i]);
                result = result + value;
               
            }
            return result;
        }
    }
}
