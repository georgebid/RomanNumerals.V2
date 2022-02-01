using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace RomanNumerals.V2
{
    public class NumberConvertor : IConvertor
    {
        // Dictionary is from the collections library.
        private Dictionary<string, int> romanNums = new Dictionary<string, int>();

        // Adds the roman numerals to the dictionary in the constructor, as it is a way to store a numeral and its value, as it allows a look up to see what each number represents.
        //changed Dictionary from a method to setting up the dictionary in the constructor body, ruling out the need for the Dictionary() method. 
        public NumberConvertor()
        {
            romanNums.Add("M", 1000);
            romanNums.Add("D", 500);
            romanNums.Add("C", 100);
            romanNums.Add("L", 50);
            romanNums.Add("X", 10);
            romanNums.Add("V", 5);
            romanNums.Add("I", 1);
        }
        public string ConvertInput(string usersInput)
        {
            // converting the users input to a char array and assigning it to the split numbers char array.
            char[] splitNumbers;
            splitNumbers = usersInput.ToCharArray();
            int multiplier = 1;
            string convertedNumeral = "";

            for (int i = splitNumbers.Length - 1; i >= 0; i--)
            {
                int splitNumber = int.Parse(splitNumbers[i].ToString());
                splitNumber = splitNumber * multiplier;
                multiplier = multiplier * 10;
                // pre-pending the converted numeral to the current conversion, so far. 
                convertedNumeral = ConvertElement(splitNumber) + convertedNumeral;
            }
            return convertedNumeral;
        }
            // returns a string, takes an int (users number)
            public string ConvertElement(int input)
        // an array is needed because we need to seperate the numerals in order to add them together.
        {
            int copyOfEnteredNumber = input;
            // validation to check if the number can be converted to a valid numeral
            Validation validation = new Validation(input);

            if (!validation.ValidationCheckNumber())
            {
                return "invalid.";
            }

            string newNumeral = "";
            // This loop will continuously run whilst subtracting from the number, until 0 is reached - subtracting the biggest roman numeral each time until its converted.

            while (input > 0)
            {
                // this is looping through the values in the dictionary.
                foreach (int value in romanNums.Values)
                {
                    // the loop runs through every value to check if it goes into our current number, and if it does it will be subtracted.
                    if (input - value >= 0)
                    {
                        //Getting the key of that pair (which is the numeral).
                        string letter = romanNums.First(pair => pair.Value == value).Key;
                        // concatenating each letter to the string
                        newNumeral += letter;
                        // essentially a running count - so it only converts what is there, taking away whats been converted. 12 - 10.
                        input -= value;
                        break;
                    }
                }
            }
            Validation resultValidation = new Validation(newNumeral);

            bool result = resultValidation.ValidationCheck();
            // if the number isn't an edge case 
            if (result == true)
            {
                return newNumeral;
            }
            else
            {
                return EdgeCaseConversion(copyOfEnteredNumber);
            }
        }
             string EdgeCaseConversion(int usersNumber)
            {
                int aboveValue = 0;
                int belowValue = 0;

                PowerOfTen powerOfTen = new PowerOfTen();

                // for each value in romanNums values, check if the value is less than or greater than the
                foreach (int value in romanNums.Values)
                {
                    if (value > usersNumber)
                    {
                        aboveValue = value;
                    }

                    if (value < usersNumber)
                    {
                        belowValue = value;
                        // if diffence between users number and the numeral above is a power of ten, we need to break out of this loop as we know it will create somethiung invalid
                        if (powerOfTen.IsValuePowerOfTen(belowValue))
                        {
                            break;
                        }
                    }
                }

                // find the difference between the above value and the. if the difference is less than or equal to the below value
                // then display the result. 
                string edgeCaseResult = "";
                int difference = aboveValue - usersNumber;

                if (difference <= belowValue)
                {
                    // finding the key for the value in the dictionary.
                    // so for 9, it returns I(the key for 1) and X(the key for 10).
                    edgeCaseResult = $"{romanNums.First(x => x.Value == belowValue).Key}{romanNums.First(x => x.Value == aboveValue).Key}";
                }
                return edgeCaseResult;
            }
    }
}

