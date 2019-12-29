using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptopals
{
    class Set1
    {
        public static string ConvertHexToBase64(string hexString)
        {
            string result = Convert.ToBase64String(ConvertToByte(hexString));
            return result;
        }

        public static byte[] CombineXOR(string string1, string string2)
        {
            byte[] ByteArray1 = ConvertToByte(string1);
            byte[] ByteArray2 = ConvertToByte(string2);
            var xorResult = new byte[string1.Length];
            for (int i = 0; i < ByteArray1.Length; i++)
            {
                xorResult[i] = (byte)(ByteArray1[i] ^ ByteArray2[i]);
            }
            return xorResult;
        }


        public static byte[] ConvertToByte(string input)
        {
            // Convert string to raw bytes
            byte[] buffer = new byte[input.Length / 2];

            for (int i = 0; i < input.Length; i++)
            {
                buffer[i / 2] = Convert.ToByte(Convert.ToInt32(input.Substring(i, 2), 16));
                i += 1;
            }
            return buffer;
        }
    }
}
