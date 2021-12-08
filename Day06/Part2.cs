using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security;
using Microsoft.VisualBasic.CompilerServices;

namespace AoC2021.Day06
{
    internal class Part2
    {
        public Int64 Solve()
        {
            var input = File.ReadAllText(@"Day06/input.txt").Split(',').Select(s => int.Parse(s)).GroupBy(i => i);
            var fish = new Int64[9];
            foreach (var g in input)
                fish[g.Key] = g.Count();

            for (int i = 0; i < 256; i++)
            {
                var spawningFish = fish[0];
                //Tick tick
                for (int x = 1; x < fish.Length; x++)
                    fish[x - 1] = fish[x];

                fish[6] += spawningFish;
                fish[8] = spawningFish;
            }

            return fish.Sum();
        }
    }
}