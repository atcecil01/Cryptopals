using System;

namespace Cryptopals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter plain text: ");
            string input = "1c0111001f010100061a024b53535009181c";
            Console.WriteLine("Enter Key: ");
            string key = "686974207468652062756c6c277320657965";
            byte[] result = Set1.CombineXOR(input, key);
            Console.WriteLine(result);
        }


    }
}
