using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;

namespace AoC2021.Day06
{
    internal class Part1
    {
        public int Solve()
        {
            var input = File.ReadAllText(@"Day06/input.txt").Split(',').Select(s => int.Parse(s)).GroupBy(i => i);
            var fish = new int[9];
            foreach (var g in input)
                fish[g.Key] = g.Count();

            for (int i = 0; i < 80; i++)
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

