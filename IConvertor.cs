using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumerals.V2
{
    internal interface IConvertor
    {
        // All examples watched said you cannot make an interface public - it doesn't need it? Although I was allowed to use it.
        // If I changed it to a dictionary in convertor, could this get added to this?
        string ConvertInput(string input);
    }
}
