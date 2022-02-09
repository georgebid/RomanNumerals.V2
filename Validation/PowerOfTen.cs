using System;


namespace RomanNumerals.V2
{
    internal class PowerOfTen
    {
        public bool IsValuePowerOfTen(int value)
        {
            return IsValuePowerOfX(10, value);
        }

        private bool IsValuePowerOfX(int X, int value)
        {
            while (value > X - 1 && value % X == 0)
            {
                value /= X;
            }
            return value == 1;
        }
    }
}
