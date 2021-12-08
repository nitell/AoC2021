using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;

namespace AoC2021.Day08
{
    internal class Part2
    {
        public int Solve()
        {
            var displays = File.ReadAllLines(@"Day08/input.txt").Select(s => new Display(s)).ToArray();
            return displays.Select(d => d.OutputSum).Sum();
        }

        public class Display
        {
            private readonly string[] _input;
            private readonly string[] _output;

            public Display(string s)
            {
                var split = s.Split('|');
                _input = split[0].Split(" ").Where(s => !String.IsNullOrEmpty(s)).ToArray();
                _output = split[1].Split(" ").Where(s => !String.IsNullOrEmpty(s)).ToArray();
            }

            public int OutputSum
            {
                get
                {

                    Dictionary<string, int> mapping = new();
                    var one = Sort(_input.Single(o => o.Length == 2));
                    var four = Sort(_input.Single(o => o.Length == 4));
                    var seven = Sort(_input.Single(o => o.Length == 3));
                    var eight = Sort(_input.Single(o => o.Length == 7));

                    var segmentA = seven.Except(one.ToCharArray()).Single();
                    var nine = Sort(_input.Single(o => o.Length == 6 && four.All(c => o.Contains(c))));

                    var segmentE = eight.Except(nine.ToCharArray()).Single();

                    var two = Sort(_input.Single(o => o.Length == 5 && o.Contains(segmentE)));
                    var three = Sort(_input.Single(o => o.Length == 5 && one.All(x => o.Contains(x))));
                    var five = Sort(_input.Single(o => o.Length == 5 && Sort(o) != two && Sort(o) != three));

                    var six = Sort(_input.Single(o => o.Length == 6 && Sort(o) != nine && o.Contains(segmentE) && !one.All(x => o.Contains(x))));

                    var zero = Sort(_input.Single(o => o.Length == 6 && Sort(o) != six && Sort(o) != nine));




                    mapping.Add(zero, 0);
                    mapping.Add(one,1);
                    mapping.Add(two, 2);
                    mapping.Add(three, 3);
                    mapping.Add(four, 4);
                    mapping.Add(five, 5);
                    mapping.Add(six,6);
                    mapping.Add(seven, 7);
                    mapping.Add(eight,8);
                    mapping.Add(nine, 9);

                    return (int) Enumerable.Range(0, 4).Select(i => mapping[Sort(_output[i])] * Math.Pow(10, 3 - i)).Sum();



                }
            }

            public string Sort(string s)
            {
                return new string(s.OrderBy(c => c).ToArray());
            }
        }
    }
}