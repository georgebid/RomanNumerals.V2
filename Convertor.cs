using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumerals.V2
{
    public class Convertor
    {
        public static int CalculateValue(char numeral)
        {
            int numeralValue;
            switch (numeral)
            {
                case 'I': numeralValue = 1; break;
                case 'V': numeralValue = 5; break;
                case 'X': numeralValue = 10; break;
                case 'L': numeralValue = 50; break;
                case 'C': numeralValue = 100; break;
                default: numeralValue = 0; break;
            }
            return numeralValue;
        }
        public static int Convert(string numerals)
            // an array is needed because we need to seperate the numerals in order to add them together.
        {
            char[] romanNum;
            romanNum = numerals.ToCharArray();
            int result = 0;
            // created an array of valid numerals so that TI wouldn't return a value.
            char[] validNumerals = { 'I', 'V', 'X', 'L', 'C' };
            // for loop that creates a value to product a result for each numeral entered.
            for (int i = 0; i < romanNum.Length; i++)
            {
                // checks if the array is valid
                int isValidIndex = Array.IndexOf(validNumerals, romanNum[i]);
                if (isValidIndex != -1)
                {
                    int value = CalculateValue(romanNum[i]);
                    result = result + value;
                    if (i > 0)
                    {
                        int previousValue = CalculateValue(romanNum[i - 1]);

                        if (previousValue < value)
                        {
                            result = result - previousValue * 2;
                        }
                    }
                }
                else {
                    result = 0;
                    Console.WriteLine("That is not a valid numeral."); 
                    break; 
                }
            }
            return result;
        }
    }
}
