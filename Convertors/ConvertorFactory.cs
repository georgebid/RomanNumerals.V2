using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumerals.V2
{
    internal class ConvertorFactory
    {
        public IConvertor GetConvertor(string usersInput)
        {
            if (Int32.TryParse(usersInput, out int inputAsInt))
            {
                return new NumberConvertor();
            }
            else
            {
                return new RomanConvertor();
            }
        }
    }
}
