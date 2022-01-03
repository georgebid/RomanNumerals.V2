using System;
using System.Collections.Generic;
using System.Text;
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
            //This regex doesn't work:  string validNumerals = @"\bM{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})\b";
            string validNumerals = @"^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
            Regex rg = new Regex(validNumerals, RegexOptions.IgnoreCase);

            if (rg.IsMatch(_numeral))
            {
                result = true;
            } else
            {
                result = false;
            }
            return result;
        }

        public bool ValidationCheckNumber()
        {
            bool resultNum = true;

                if (_number < 3999)
                {
                    resultNum = true;
                }
                else
                {
                    resultNum = false;
                }
            return resultNum;
        }
        // validation to run before anything else happens
        // the regex also contains info to determine 
    }
}
