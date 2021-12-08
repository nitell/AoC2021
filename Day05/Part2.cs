using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security;
using Microsoft.VisualBasic.CompilerServices;

namespace AoC2021.Day05
{
    internal class Part2
    {
        public int Solve()
        {
            var input = File.ReadAllLines(@"Day05/input.txt");
            var grid = new int[1000, 1000];
            var lines = input.Select(s => new Line(s)).ToArray();
            foreach (var line in lines)
            foreach (var p in line.Points)
                grid[p.X, p.Y] += 1;



            var sum = 0;
            for (var y = 0; y < grid.GetLength(1); y++)
            {
                for (var x = 0; x < grid.GetLength(0); x++)
                {

                    if (grid[x, y] > 1)
                        sum++;
                }

            }

            return sum;
        }
    }
}