using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2021.Day03
{
    internal class Part1
    {
        public int Solve()
        {
            var input = File.ReadAllLines(@"Day03/input.txt");
            var counts = Enumerable.Range(0, input.First().Length).Select(i => input.Select(s => s[i]).ToArray()).Select(p => p.GroupBy(i => i).OrderBy(g => g.Count()));
            var gammaBits = counts.Select(g => g.Last().Key).ToArray();
            var epsilonBits = counts.Select(g => g.First().Key).ToArray();

            var gamma = ToDec(gammaBits); 
            var epsilon = ToDec(epsilonBits);

            return gamma * epsilon;
        }

        private int ToDec(char[] bits)
        {
            return bits.Select((val, i) => val == '1' ? (int)Math.Pow(2, bits.Length - 1 - i) : 0).Sum();
        }
    }
}