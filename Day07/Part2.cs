using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security;
using Microsoft.VisualBasic.CompilerServices;

namespace AoC2021.Day07
{
    internal class Part2
    {
        public Int64 Solve()
        {
            var input = File.ReadAllText(@"Day07/input.txt").Split(',').Select(s => int.Parse(s));
            return Enumerable.Range(input.Min(), input.Max() - input.Min()).Select(alignAt => input.Select(a => CalcFuel(a,alignAt)).Sum()).Min();
        }

        private int CalcFuel(int from, int to)
        {
            return Enumerable.Range(1, Math.Abs(to - from)).Sum();
        }
    }
}