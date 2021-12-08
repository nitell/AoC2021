using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;

namespace AoC2021.Day07
{
    internal class Part1
    {
        public int Solve()
        {
            var input = File.ReadAllText(@"Day07/input.txt").Split(',').Select(s => int.Parse(s));
            
            return Enumerable.Range(input.Min(), input.Max() - input.Min()).Select(alignAt => input.Select(a => Math.Abs(a - alignAt)).Sum()).Min();
            
        }
    }
}

