using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;

namespace AoC2021.Day05
{
    internal class Part1
    {
        public int Solve()
        {
            var input = File.ReadAllLines(@"Day05/input.txt");
            var grid = new int[1000,1000];
            var lines = input.Select(s => new Line(s)).ToArray();
            foreach (var line in lines.Where(l => l.From.Y == l.To.Y || l.From.X == l.To.X))
                foreach(var p in line.Points)
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

    internal class Line
    {
        public Line(string s)
        {
            var parts = s.Split("->");
            var from = parts[0].Split(",");
            var to = parts[1].Split(",");

            From = new Point(int.Parse(from[0]), int.Parse(from[1]));
            To = new Point(int.Parse(to[0]), int.Parse(to[1]));

            Vector = new Point(Math.Sign(To.X - From.X), Math.Sign(To.Y - From.Y));
        }

        public Point To { get; set; }

        public Point From { get; set; }

        public Point Vector { get; set; }



        public IEnumerable<Point> Points
        {
            get
            {
                var p = From;
                yield return p;
                while (p != To)
                {
                    p = new Point(p.X + Vector.X, p.Y + Vector.Y);
                    yield return p;
                }
            }
        }
    }
}

