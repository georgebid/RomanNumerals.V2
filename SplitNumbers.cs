using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumerals.V2
{
    internal class SplitNumbers
    {
        NumberConvertor numberConvertor = new NumberConvertor();
        /* The below checks users number case by case. First, its taken as an int, and then split into a char array. So it few each number individually. 
           so  299 will be turned into 200, 90 and 9/ cc cx ix not 2 9 9 
           The for loop works backwards, so starting from the smallest number in the array and works it way up. This way we can increase the multipler as we go, 
           creating the 10's and 100's numbers.
        */

        public string Split(string usersInput)
        {
            char[] splitNumbers;
            splitNumbers = usersInput.ToCharArray();
            int multiplier = 1;
            string convertedNumeral = "";

            for (int i = splitNumbers.Length - 1; i >= 0; i--)
            {
                int splitNumber = int.Parse(splitNumbers[i].ToString());
                splitNumber = splitNumber * multiplier;
                multiplier = multiplier * 10;
                convertedNumeral = numberConvertor.ConvertToNumeral(splitNumber) + convertedNumeral;
            }
            return $"Your numeral is {convertedNumeral}";
        }
    }
}
