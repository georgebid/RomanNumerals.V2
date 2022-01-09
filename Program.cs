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
            Console.WriteLine($"You entered {usersInput}");

            if (Int32.TryParse(usersInput, out int usersInputAsInt))
            {
                char[] splitNumbers;
                splitNumbers = usersInput.ToCharArray();
                int multiplier = 1;
                string convertedNumeral = "";

                for (int i = splitNumbers.Length - 1; i >= 0; i--)
                {
                    int splitNumber = int.Parse(splitNumbers[i].ToString());
                    splitNumber = splitNumber * multiplier;
                    multiplier = multiplier * 10;
                    convertedNumeral = numberConvertor.ConvertToNumeral(splitNumber) + convertedNumeral;
                }
                Console.WriteLine($"Your numeral is {convertedNumeral}");
            }
            else
            {
                Console.WriteLine($"Your numeral converted to a number is: {convertor.Convert(usersInput)}");
            }
        }
    }
}
