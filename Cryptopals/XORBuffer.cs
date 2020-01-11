using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptopals
{
    public class XORBuffer
    {
        public int XORKey;
        public string XORResult;
        public double Frequency;

        public XORBuffer(int XORKey, string XORResult, double Frequency)
        {
            this.XORKey = XORKey;
            this.XORResult = XORResult;
            this.Frequency = Frequency;
        }
    }
}
