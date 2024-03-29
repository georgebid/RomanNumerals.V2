﻿using System;

namespace RomanNumerals.V2
{
    public class RomanConvertor : IConvertor
    {
        public int CalculateValue(char numeral)
        {
            int numeralValue;
            switch (numeral)
            {
                case 'I': numeralValue = 1; break;
                case 'V': numeralValue = 5; break;
                case 'X': numeralValue = 10; break;
                case 'L': numeralValue = 50; break;
                case 'C': numeralValue = 100; break;
                case 'D': numeralValue = 500; break;
                case 'M': numeralValue = 1000; break;
                default: numeralValue = 0; break;
            }
            return numeralValue;
        }
        public void ConvertInput(NumeralConversion input)
            // an array is needed because we need to seperate the numerals in order to add them together.
        {

            Validation validation = new Validation(input.EnteredValue);
            char[] romanNum;
            romanNum = input.EnteredValue.ToCharArray();
            // regex or strings could be used instead of a array, remove letters which aren't valid - from a string.

            // for loop that creates a value to product a result for each numeral entered.
            // could loop backwards - works better logically. The witness game & human resource machine. 
            if (!validation.ValidationCheck())
            {
                Console.WriteLine("That is not a valid numeral");
               // return "0";
            }
                int result = 0;
            // loop through for however many times there is a element in the array, keeping track of where it is in the array.
            for (int i = 0; i < romanNum.Length; i++)
            {
                {
                    int value = CalculateValue(romanNum[i]);
                    result += value;
                    if (i > 0)
                    {
                        int previousValue = CalculateValue(romanNum[i - 1]);

                        if (previousValue < value)
                        {
                            // this is to account for the wrongly added amount to the previous value.
                            result -= previousValue * 2;
                        }
                    }
                }
            }
            input.NewValue = result.ToString();
        }
    }
}
