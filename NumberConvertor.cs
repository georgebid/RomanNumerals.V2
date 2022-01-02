﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace RomanNumerals.V2
{
    class NumberConvertor
    {
        //private OrderedDictionary romanNums = new OrderedDictionary();
        private Dictionary<string, int> romanNums = new Dictionary<string, int>();
        
        // Adds the roman numerals to the dictionary
        internal void Dictionary()
        {

            romanNums.Add("M", 1000);
            romanNums.Add("D", 500);
            romanNums.Add("C", 100);
            romanNums.Add("L", 50);
            romanNums.Add("X", 10);
            romanNums.Add("V", 5);
            romanNums.Add("I", 1);
        }

        public string GetValues(int number)
            
        {
            // validation to check if the number can be converted to a valid numeral
            Validation validation = new Validation(number);

            if (!validation.ValidationCheckNumber())
            {
                return "This is not a valid numeral.";
            }

                Dictionary();
                string newNumeral = "";
                // This loop will continuously run whilst subtracting from the number, until 0 is reached - subtracting the biggest roman numeral each time until its converted.

                while (number > 0)
                {
                    foreach (int d in romanNums.Values)
                    {
                        // number is printed here to show the loop working.
                        Console.WriteLine(number);
                        Console.WriteLine(d);
                        // the loop runs through every value to check if it goes into our current number, and if it does it will be subtracted.
                        if (number - d >= 0)
                        {
                            // google first or default
                            // this is looping through the roman numerals and checking if the value is equal to d, then getting the key of that pair.
                            string letter = romanNums.FirstOrDefault(x => x.Value == d).Key;
                            // adding each letter to the string
                            newNumeral = newNumeral + letter;
                            // essentially a running count
                            number = number - d;
                            break;
                        }
                    }
                }
                return newNumeral;
        }
    }
}