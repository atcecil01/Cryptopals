using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Cryptopals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Working...");
            // returns the current directory path to a string variable
            string currentDirectory = Directory.GetCurrentDirectory();
            // Instantiates a new DirectoryInfo object with the current directory(provides additional properties and methods)
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "data.txt");
            var readerResults = stringReader(fileName);
            var XORResults = new List<XORBuffer>();
            var mostLikelyList = new List<XORBuffer>();
            string finalResult = "";
            foreach(string line in readerResults)
            {
                XORResults = Set1.XORDecipher(line);
                XORBuffer mostLikely = Set1.GetHighestFequency(XORResults);
                mostLikelyList.Add(mostLikely);
                XORBuffer mostLikelyFinal = Set1.GetHighestFequency(mostLikelyList);
                finalResult = mostLikelyFinal.XORResult;
            }
            Console.WriteLine("Solution: " + finalResult);
            Console.WriteLine("Complete");
        }

        public static List<string> stringReader(string fileName)
        {
            string line;
            List<string> results = new List<string>();
            
            StreamReader file = new StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                results.Add(line);    
            }
            return results;
        }
    }
}
