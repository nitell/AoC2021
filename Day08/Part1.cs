using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;

namespace AoC2021.Day08
{
    internal class Part1
    {
        public int Solve()
        {
            var uniqueLengths = new[] {2, 4, 3, 7};
            var input = File.ReadAllLines(@"Day08/input.txt").Select(s => s.Split('|')[1].Split(" ").Where(s => !String.IsNullOrEmpty(s)).ToArray()).ToArray();
            return input.SelectMany(o => o.Where(s => uniqueLengths.Contains(s.Length))).Count();
        }
    }
}

