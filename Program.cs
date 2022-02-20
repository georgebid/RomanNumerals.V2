using System;

namespace RomanNumerals.V2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a roman numeral or a number: ");

            string usersInput = Console.ReadLine().ToUpper();

            NumeralConversion numeralConversion = new NumeralConversion();

            numeralConversion.EnteredValue = usersInput;

            Console.WriteLine($"You entered {usersInput}");

            ConvertorFactory convertorFactory = new ConvertorFactory();

           // ReadAndWriteToFile readAndWriteToFile = new ReadAndWriteToFile();

            IConvertor convertor = convertorFactory.GetConvertor(usersInput);

            convertor.ConvertInput(numeralConversion);

            DataStore resultWriter = new DataStore();

            Console.WriteLine(value: $"Your numeral converted to a number is: {numeralConversion.NewValue}");

            Console.WriteLine("\nPrevious entries and conversions: ");

            resultWriter.Read(numeralConversion);
            resultWriter.Write(numeralConversion);
            
        }
    }
}
