using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptopals
{
    class Set1
    {
        public static string ConvertHexToBase64(string hexString)
        {
            string result = Convert.ToBase64String(StringToByteArray(hexString));
            return result;
        }

        public static string CombineXOR(string string1, string string2)
        {
            byte[] ByteArray1 = StringToByteArray(string1);
            byte[] ByteArray2 = StringToByteArray(string2);
            var xorResult = new byte[ByteArray1.Length];
            for (int i = 0; i < ByteArray1.Length; i++)
            {
                xorResult[i] = (byte)(ByteArray1[i] ^ ByteArray2[i]);

            }

            string HexValue = ByteArrayToString(xorResult);
            Console.WriteLine("Hex: " + HexValue);
            //TODO: return value is twice as long and contains extra 00's at end?
            return HexValue;
        }


        public static byte[] StringToByteArray(string input)
        {
            byte[] buffer = new byte[input.Length / 2];

            for (int i = 0; i < input.Length; i++)
            {
                buffer[i / 2] = Convert.ToByte(Convert.ToInt32(input.Substring(i, 2), 16));
                i += 1;
            }
            return buffer;
        }
        public static string ByteArrayToString(byte[] byteArray)
        {
            var hex = new StringBuilder(byteArray.Length * 2);
            foreach (var b in byteArray)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
