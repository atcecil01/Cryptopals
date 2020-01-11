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
            string message = "Burning 'em, if you ain't quick and nimble I go crazy when I hear a cymbal";
            string key = "ICE";
            string result = Set1.repeatingXOR(message, key);
            Console.WriteLine(result);
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
