using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security;
using Microsoft.VisualBasic.CompilerServices;

namespace AoC2021.Day03
{
    internal class Part2
    {

        public char GetOxygenBit(char[] values)
        {
            var zeroCount = values.Count(v => v == '0');
            var oneCount = values.Count(v => v == '1');
            return oneCount >= zeroCount ? '1' : '0';
        }

        public char GetScrubberBit(char[] values)
        {
            var zeroCount = values.Count(v => v == '0');
            var oneCount = values.Count(v => v == '1');
            return zeroCount <= oneCount  ? '0' : '1';
        }


        public int Solve()
        {
               var input = File.ReadAllLines(@"Day03/input.txt");
               var oxygenString = Filter(input, GetOxygenBit);
               var scrubberString = Filter(input, GetScrubberBit);

               return ToDec(oxygenString.ToCharArray()) * ToDec(scrubberString.ToCharArray());
        }


        private string Filter(string[] input, Func<char[],char> getBit)
        {
            var result = input.ToList();
            string filter = "";
            for (int i = 0; i < input.First().Length; i++)
            {
                filter += getBit(result.Select(s => s[i]).ToArray());
                result = result.Where(s => s.StartsWith(filter)).ToList();
                if (result.Count() == 1)
                    return result.First();
            }

            throw new Exception(".....");
        }

        private int ToDec(char[] bits)
        {
            return bits.Select((val, i) => val == '1' ? (int)Math.Pow(2, bits.Length - 1 - i) : 0).Sum();
        }
    }
}