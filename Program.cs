using System;

namespace RomanNumerals.V2
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberConvertor numberConvertor = new NumberConvertor();
            Convertor convertor = new Convertor();

            Console.WriteLine("Please enter a roman numeral or a number: ");
            
            string usersInput = Console.ReadLine().ToUpper();

            if (Int32.TryParse(usersInput, out int usersInputAsInt))
            {
                Console.WriteLine(numberConvertor.GetValues(usersInputAsInt));
            }
            else
            {
                Console.WriteLine(convertor.Convert(usersInput));
            }
        }
    }
}
