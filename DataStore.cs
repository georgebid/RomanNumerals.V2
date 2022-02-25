using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals.V2
{
    internal class DataStore
    {
        public List<string> EnteredInputs { get; set; }
        public List<string> Results { get; set; }

        // private write data method.
        private void WriteData(StreamWriter writer)
        {
            for (int i = 0; i < EnteredInputs.Count; i++)
            {
                writer.WriteLine($"{EnteredInputs.ElementAt(i)},{Results.ElementAt(i)}");
            } 
        }
        // declare the file that will be written to and read from. Outside of each method so they can both access it.
        string numeralHistoryData = @"C:\Users\Georgina.Bidder\.vscode\textFile.csv";
        // write to the file.
        public void Write(NumeralConversion numeralConversion)
        {
            // added to catch any edge cases. 
            if (numeralConversion == null || numeralHistoryData.Length == 0)
            {
                Console.WriteLine("There are no records.");
            }
            else // if the numeral conversion is valid then write the entered input and the result (taken from the numeral conversion class).
            {
                EnteredInputs.Add(numeralConversion.EnteredValue);
                Results.Add(numeralConversion.NewValue);
                // initalize a new instance of the built in StreamWriter class so that we can write to the numeralHistoryData file.
                using var writer = new StreamWriter(numeralHistoryData);
                //the private writedata method is declared, taking the new instance of StreamWriter.
                WriteData(writer);
            }
        }

        // read the file.
        public IList<string[]> Read(NumeralConversion numeralConversion)
        {
            var results = new List<string[]>();

            if (!File.Exists(numeralHistoryData))
            {
                Console.WriteLine($"The data file does not exist at {numeralHistoryData}.");
                return results;
            }
            using (var reader = new StreamReader(numeralHistoryData))
            {
                string output;
                EnteredInputs = new List<string>();
                Results = new List<string>();
                while ((output = reader.ReadLine()) != null)
                {
                    List<string> historicData = new List<string>();
                    var stringBuilder = new StringBuilder();
                    stringBuilder.Append(output);
                    // temp array to hold each line as it loops
                    string[] tempArray = stringBuilder.ToString().Split(',');
                    foreach (string t in tempArray)
                    {
                        historicData.Add(t);
                    }

                    if (historicData.ElementAt(0) != "" && historicData.Count < 10)
                    {
                        EnteredInputs.Add(historicData.ElementAt(0));
                        Results.Add(historicData.ElementAt(1));
                    }
                }
                //the t
                if (EnteredInputs.Count >= 4)
                {
                    EnteredInputs.RemoveAt(0);
                    Results.RemoveAt(0);
                }
                for (int i = 0; i < EnteredInputs.Count; i++)
                {
                    Console.WriteLine($"{EnteredInputs.ElementAt(i)}, {Results.ElementAt(i)}");
                }
            }
            return results;
        }
    }
}



























// Stream numeralHistoryData = new FileStream(@"C:\Users\Georgina.Bidder\.vscode\textFile.csv", FileMode.Create, FileAccess.Write);
//StreamWriter writer = new StreamWriter(numeralHistoryData);
// write to file
//try
//{
//    // FileStream stream = new FileStream(numeralHistoryData, FileMode.Open);

//    using (FileStream stream = new FileStream(numeralHistoryData, FileMode.Open))
//    {
//        using (var writer = new BinaryWriter(stream, Encoding.UTF8))
//        {
//            writer.Write($"{EnteredInputs}, {Results}");
//            File.AppendText(numeralHistoryData);
//        }
//    }
//}
//catch (Exception exp)
//{
//    Console.Write(exp.Message);
//}
//        }
//        public void DisplayValues()
//{
//    string readValues;
//    if (File.Exists(numeralHistoryData))
//    {
//        using (var stream = File.Open(numeralHistoryData, FileMode.Open))
//        {
//            using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
//            {
//                readValues = reader.ReadString();
//            }
//        }

//    }














//// StreamReader reader = new StreamReader(File.OpenRead(@"C:\Users\Georgina.Bidder\.vscode\textFile.csv"));

//// object written to files
//IFormatter formatter = new BinaryFormatter();
//Stream stream = new FileStream(@"C:\Users\Georgina.Bidder\.vscode\textFile.csv", FileMode.Create, FileAccess.Write);

//formatter.Serialize(stream, numeralConversion);
//        stream.Close();
//        // deserialization to extract the data from the application for further use.
//        stream = new FileStream(@"C:\Users\Georgina.Bidder\.vscode\textFile.csv", FileMode.Open, FileAccess.Read);

//NumeralConversion usersInputs = (NumeralConversion)formatter.Deserialize(stream);

//Console.WriteLine($"{usersInputs.OldValue} - {usersInputs.NewValue}");

//        //stream writer, text writer, append - append to end. text over binary. writer.WriteLine. create streamwriter, give it the path(as a string) writer.writeline. 
//        // stream reader, string reader, string builder.

