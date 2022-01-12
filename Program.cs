using System;

namespace RomanNumerals.V2
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberConvertor numberConvertor = new NumberConvertor();
            Convertor convertor = new Convertor();
            SplitNumbers splitNumbers = new SplitNumbers();
            

            Console.WriteLine("Please enter a roman numeral or a number: ");
            
            string usersInput = Console.ReadLine().ToUpper();
            Console.WriteLine($"You entered {usersInput}");


            if (Int32.TryParse(usersInput, out int usersInputAsInt))
            {
                Validation validation = new Validation(usersInputAsInt);


                if (validation.ValidationCheckNumber())
                {
                    string numeral = splitNumbers.Split(usersInput);
                    Console.WriteLine(numeral);
                }
                else
                {
                    Console.WriteLine("That number cannot be converted.");
                }
            }
            else
            {
                Console.WriteLine($"Your numeral converted to a number is: {convertor.Convert(usersInput)}");
            }
        }
    }
}
