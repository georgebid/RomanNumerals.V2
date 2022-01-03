using System;
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
            int originalUserInput = number;
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
            Validation resultValidation = new Validation(newNumeral);

            bool result = resultValidation.ValidationCheck();
            // if the number isn't and edge case 
            if (result == true)
            {
                return newNumeral;
            } else
            {
                return FallbackConversion(originalUserInput);
            }
        }

        public string FallbackConversion(int usersNumber)
        {
            int aboveValue = 0;
            int belowValue = 0;

            PowerOfTen powerOfTen = new PowerOfTen();

            // for each value in romanNums values, check if the value is less than or greater than the usersNumber.
            foreach (int value in romanNums.Values)
            {
                if (value > usersNumber)
                {
                    aboveValue = value;
                }
                // if the value is below the usersNumber then check if its a power of 10. if its not, then repeat, when a power of 10 is reached - break out of the loop.
                if (value < usersNumber)
                {
                    belowValue = value;
                    
                   if (powerOfTen.IsValuePowerOfTen(belowValue))
                   {
                        Console.WriteLine("If here");
                      break;
                   }
                }
            }
            // find the difference between the above value and the usersNumber. if the difference is less than or equal to the below value
            // then display the result. 
            string fallbackResult = "";
            int difference = aboveValue - usersNumber;

            if (difference <= belowValue)
            {
                // finding the key for the value in the dictionary.
                // so for 9, it returns I(the key for 1) and X(the key for 10).
                fallbackResult = $"{romanNums.FirstOrDefault(x => x.Value == belowValue).Key}{romanNums.FirstOrDefault(x => x.Value == aboveValue).Key}";
            }
            return fallbackResult;
        }
        // this is currently too generalised - it doesn't work for 29 - because the rule only works for simplier number, e.g. when there are only two numerals - Above and Below.
        // 29 should be XXIX, we should take the 20 and pass only the 9 to this function.
    }
}
