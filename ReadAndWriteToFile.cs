using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace RomanNumerals.V2
{
    internal class ReadAndWriteToFile
    {
       public List<string> EnteredInputs { get; set; }
        public List<string> Results { get; set; }

        public void WriteUsersInput(string usersInput)
        {
            string filePath = @"C:\Users\Georgina.Bidder\.vscode\textFile.txt";

          //  WriteToFile writeToFile = new WriteToFile();

            List<string> lines = File.ReadAllLines(filePath).ToList();

            EnteredInputs = lines;

            EnteredInputs.Add(usersInput);

            List<string> output = new List<string>();

            foreach (var value in EnteredInputs)
            {
                output.Add($"{value}");
                Console.WriteLine($"{value}");
            }

            if (lines.Count > 10)
            {
                output.RemoveAt(0);
            }

            File.WriteAllLines(filePath, output);

           // return output;
        }
        public void WriteUsersResult(string result)
        {
            string filePath = @"C:\Users\Georgina.Bidder\.vscode\textFile.txt";

            //  WriteToFile writeToFile = new WriteToFile();

            List<string> textFile = File.ReadAllLines(filePath).ToList();

            Results = textFile;

            Results.Add(result);

            List<string> resultOutput = new List<string>();

            foreach (var results in Results)
            {
                resultOutput.Add($"{results}");
                Console.WriteLine($"{results}");
            }

            if (textFile.Count > 10)
            {
                resultOutput.RemoveAt(0);
            }

            File.WriteAllLines(filePath, resultOutput);
        }
    }
}


//public void ReadAndWriteFiles()
//{
//    //string filePath = @"C:\Users\Georgina.Bidder\Desktop";

//    //List<string> dataLog = File.ReadAllLines(filePath).ToList();

//    //foreach (string data in dataLog)
//    //{
//    //    Console.WriteLine(data);
//    //}
//    Console.ReadLine();
//}