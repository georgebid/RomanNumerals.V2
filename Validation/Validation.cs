using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RomanNumerals.V2
{
    internal class Validation
    {
        private string _numeral;
        private int _number;

        public Validation(string numerals)
        {
            _numeral = numerals;
        }
        public Validation(int number)
        {
            _number = number;
        }

        public bool ValidationCheck()
        {
            bool result = true;
            string validNumerals = @"^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
            // the regex also contains info to determine whether a certain amount of letters in groups is valid. Which rules out the need for any extra validation.
            Regex rg = new Regex(validNumerals, RegexOptions.IgnoreCase);

            if (rg.IsMatch(_numeral))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public bool ValidationCheckNumber()
        {
            bool resultNum = true;

            if (_number < 4000)
            {
                resultNum = true;
            }
            else
            {
                resultNum = false;
            }
            return resultNum;
        }
    }  
}
