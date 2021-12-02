using System.IO;
using System.Linq;

namespace AoC2021.Day01
{
    internal class Part1
    {
        public int Solve()
        {
            var input = File.ReadAllLines(@"Day01/input.txt").Select(s => int.Parse(s)).ToArray();
            return input.Zip(input.Skip(1), (a, b) => b > a ? 1 : 0).Sum();
        }
    }
}