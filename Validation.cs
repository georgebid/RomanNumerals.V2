using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RomanNumerals.V2
{
    internal class Validation
    {
        private string _numeral;

        public Validation(string numerals)
        {
            _numeral = numerals;
        }
       
        public bool ValidationCheck()
        {

            bool result = true;
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
        // validation to run before anything else happens

    }
}
