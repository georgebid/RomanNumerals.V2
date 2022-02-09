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
    // the datastore should only read and write to a file.
    // a seperate class should display the data
    [Serializable]
    internal class DataStore
    {
       public List<string> EnteredInputs { get; set; }
        public List<string> Results { get; set; }


        public void Write(NumeralConversion numeralConversion)
        {
            // StreamReader reader = new StreamReader(File.OpenRead(@"C:\Users\Georgina.Bidder\.vscode\textFile.csv"));
            

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"C:\Users\Georgina.Bidder\.vscode\textFile.csv", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, numeralConversion);
            stream.Close();

            stream = new FileStream(@"C:\Users\Georgina.Bidder\.vscode\textFile.csv", FileMode.Open, FileAccess.Read);

            NumeralConversion newNumCon = (NumeralConversion)formatter.Deserialize(stream);

            Console.WriteLine($"{newNumCon.OldValue} - {newNumCon.NewValue}");
        }
    }
}
//NumeralConversion numeralCon = new NumeralConversion();

//IFormatter formatter = new BinaryFormatter();
//Stream stream = new FileStream(@"C:\Users\Georgina.Bidder\.vscode\textFile.csv", FileMode.Create, FileAccess.Write);

//formatter.Serialize(stream, numeralCon);
//stream.Close();

//stream = new FileStream(@"C:\Users\Georgina.Bidder\.vscode\textFile.csv", FileMode.Open, FileAcccess.Read);

//NumeralConversion newNumCon = (NumeralConversion)formatter.Deserialize(stream);

//Console.WriteLine(newNumCon.NewValue);
//Console.WriteLine(newNumCon.OldValue);

//Console.ReadKey();