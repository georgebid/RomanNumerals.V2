﻿using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

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

            string filePath = @"C:\Users\Georgina.Bidder\.vscode\textFile.txt";


            // Below is WIP.

            WriteToFile values = new WriteToFile();

            List<string> lines = File.ReadAllLines(filePath).ToList();

            values.EnteredInputs = lines;

            values.EnteredInputs.Add(usersInput);

            List<string> output = new List<string>();


            foreach (var value in values.EnteredInputs)
            {
                output.Add($"{value}");
            }

            if (lines.Count > 30)
            {
                output.RemoveAt(0);
            }

            File.WriteAllLines(filePath, output);

           

            //foreach (string outputs in output)
            //{
            //    Console.WriteLine($"{values.EnteredInput} {output.PreviouslyEnteredInput}");
            //}

            //    string[] entries = line.Split(',');

            //    ReadAndWrite readAndWrite = new ReadAndWrite();

            //    readAndWrite.EnteredInput = entries[0];

            //    readAndWrite.PreviouslyEnteredInput = entries[1];

            //    values.Add(readAndWrite);
            //}

            //foreach (var value in values)
            //{
            //    Console.WriteLine($"{value.EnteredInput} {value.PreviouslyEnteredInput}");
            //}
        }
    }
}
