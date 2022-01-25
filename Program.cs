using System;

namespace RomanNumerals.V2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a roman numeral or a number: ");

            string usersInput = Console.ReadLine().ToUpper();

            Console.WriteLine($"You entered {usersInput}");

            ConvertorFactory convertorFactory = new ConvertorFactory();

            IConvertor convertor = convertorFactory.GetConvertor(usersInput);

            string result = convertor.ConvertInput(usersInput);

            Console.WriteLine(value: $"Your numeral converted to a number is: {result}");
        }
    }
}
