using System.IO;
using System.Linq;

namespace AoC2021.Day01
{
    internal class Part2
    {
        public int Solve()
        {
            var input = File.ReadAllLines(@"Day01/input.txt").Select(s => int.Parse(s)).ToArray();
            var windows = Enumerable.Range(0, input.Count() - 2).Select(i => input[i] + input[i + 1] + input[i + 2])
                .ToArray();
            return Enumerable.Range(0, windows.Count() - 1).Count(i => windows[i + 1] > windows[i]);
        }
    }
}