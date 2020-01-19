using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cryptopals
{
    class Set1
    {
        public static int GetHammingDistance(string str1, string str2)
        {
            if (str1.Length != str2.Length) throw new ArgumentException("Values must be same length");

            byte[] x = Encoding.ASCII.GetBytes(str1);
            byte[] y = Encoding.ASCII.GetBytes(str2);

            string xstr = string.Join(" ", x.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
            string ystr = string.Join(" ", y.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));

            int i = 0, distance = 0;
            while (i < xstr.Length)
            {
                if (xstr[i] != ystr[i])
                    distance++;
                i++;
            }
            return distance;
        }
        public static string repeatingXOR(string message, string key)
        {
            // XOR's a message against a repeating key
            string expandedkey = ExpandKey(message, key);
            string hexMessage = StringToHex(message);
            string hexKey = StringToHex(expandedkey);
            string result = CombineXOR(hexMessage, hexKey);
            return result;
        }
        public static string ExpandKey(string hex, string key)
        {
            var expandedKey = string.Empty;
            while (expandedKey.Length < hex.Length)
            {
                expandedKey += key;
            }
            while (expandedKey.Length > hex.Length)
            {
                expandedKey = expandedKey.Remove((expandedKey.Length) - 1, 1);
            }
            return expandedKey;
        }
        public static string ConvertHexToBase64(string hexString)
        {
            string result = Convert.ToBase64String(StringToByteArray(hexString));
            return result;
        }

        public static string CombineXOR(string string1, string string2)
        {
            //XOR's each byte in two strings of equal length
            byte[] ByteArray1 = StringToByteArray(string1);
            byte[] ByteArray2 = StringToByteArray(string2);
            var XORResult = new byte[ByteArray1.Length];
            for (int i = 0; i < ByteArray1.Length; i++)
            {
                XORResult[i] = (byte)(ByteArray1[i] ^ ByteArray2[i]);

            }
            string HexValue = ByteArrayToString(XORResult);
            return HexValue;
        }

        public static string StringToHex(string input)
        {
            byte[] buffer = Encoding.Default.GetBytes(input);
            var hexString = BitConverter.ToString(buffer);
            hexString = hexString.Replace("-", "");
            return hexString;
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

        public static List<XORBuffer> XORDecipher(string input)
        {
            var outputs = new List<XORBuffer>();
            byte[] buffer = StringToByteArray(input);
            var XORResult = new byte[buffer.Length];
            foreach (var key in Enumerable.Range(0, 127))
            {
                for (int i = 0; i < XORResult.Length; i++)
                {
                    XORResult[i] = (byte)(buffer[i] ^ key);
                }
                double coefficient = CheckFrequency(Encoding.ASCII.GetString(XORResult));
                XORBuffer xorBuffer = new XORBuffer(key, Encoding.ASCII.GetString(XORResult), coefficient);
                outputs.Add(xorBuffer);
            }
            return outputs;
        }

        public static double CheckFrequency(string input)
        {
            var chars = input.ToUpper().GroupBy(c => c).Select(g => new { g.Key, Count = g.Count() });
            double coefficient = 0;

            foreach (var c in chars)
            {
                if(LetterFrequency.TryGetValue(c.Key, out var frequency))
                {
                    coefficient += Math.Sqrt(frequency * c.Count / input.Length);
                }
            }
            return coefficient;
        }

        public static readonly Dictionary<char, double> LetterFrequency = new Dictionary<char, double>
        {
            // source: http://pi.math.cornell.edu/~mec/2003-2004/cryptography/subs/frequencies.html
            {'E', 12.02}, {'T', 9.10}, {'A', 8.12}, {'O', 7.68}, {'I', 7.31}, {'N', 6.95},
            {'S', 6.28}, {'R', 6.02}, {'H', 5.92}, {'D', 4.32}, {'L', 3.98}, {'U', 2.88},
            {'C', 2.71}, {'M', 2.61}, {'F', 2.30}, {'Y', 2.11}, {'W', 2.09}, {'G', 2.03},
            {'P', 1.82}, {'B', 1.49}, {'V', 1.11}, {'K', 0.69}, {'X', 0.17}, {'Q', 0.11},
            {'J', 0.10}, {'Z', 0.07 }, {' ', 0.19}
        };

        public static XORBuffer GetHighestFequency(List<XORBuffer> input)
        {
            XORBuffer mostLikely = input.OrderByDescending(x => x.Frequency).FirstOrDefault();
            return mostLikely;
        }
    }
}
