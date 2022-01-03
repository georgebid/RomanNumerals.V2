﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumerals.V2
{
    class PowerOfTen
    {
        public bool IsValuePowerOfTen(int value)
        {
            Console.WriteLine("value here is" + value);
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
