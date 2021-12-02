using System.IO;
using System.Linq;

namespace AoC2021.Day01
{
    internal class Part1
    {
        public int Solve()
        {
            var input = File.ReadAllLines(@"Day01/input.txt").Select(s => int.Parse(s)).ToArray();
            return Enumerable.Range(0, input.Length - 1).Count(i => input[i + 1] > input[i]);
        }
    }
}