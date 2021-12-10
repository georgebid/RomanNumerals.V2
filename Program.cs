using System;

namespace RomanNumerals.V2
{
    class Program
    {
        static void Main(string[] args)
        {
            Convertor convertor = new Convertor();
            Console.WriteLine("Please enter a roman numeral: ");
            string usersNumeral = Console.ReadLine().ToUpper();
            Console.WriteLine(Convertor.CalculateValue(usersNumeral));
        }
    }
}
