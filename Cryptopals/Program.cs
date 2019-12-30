using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptopals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter hex string: ");
            string input = "1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736";
            //Console.WriteLine("Enter Key: ");
            //string key = "";
            Dictionary<int, string> result = Set1.XORDecipher(input);
            Console.WriteLine(result);

        }


    }
}
