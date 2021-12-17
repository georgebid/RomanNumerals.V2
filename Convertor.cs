using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumerals.V2
{
    public class Convertor
    {
        // instance of a convertor rather than static.
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
            Validation(romanNum);
            // validation to run before anything else happens
            int result = 0;
            // created an array of valid numerals so that TI wouldn't return a value.
            char[] validNumerals = { 'I', 'V', 'X', 'L', 'C' };
            // regex or strings could be used instead of a array, remove letters which aren't valid - from a string.

            // for loop that creates a value to product a result for each numeral entered.
            // could loop backwards - works better logically. The witness game & human resource machine. 
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
        // below doesnt work.
        // The idea is that it would check for invalid numeral, create error score and if the error score is 0 > then the convert method doesnt run.
        public static int Validation(char[] romanNum)
        {
           
            if (romanNum.Length > 4)
            {
                if (romanNum[0] == romanNum[1] && romanNum[0] == romanNum[2] && romanNum[0] == romanNum[3])
                {
                    bool invalidNumeral = true;
                   if (invalidNumeral == true)
                     {

                    } 
                }
            }
            return 0;
        } 
    }
}
