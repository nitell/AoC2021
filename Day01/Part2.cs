using System.IO;
using System.Linq;

namespace AoC2021.Day01
{
    internal class Part2
    {
        public int Solve()
        {
            var input = File.ReadAllLines(@"Day01/input.txt").Select(s => int.Parse(s)).ToArray();
            var windows = input.Zip(input.Skip(1)).Zip(input.Skip(2))
                .Select(o => o.First.First + o.First.Second + o.Second).ToArray(); 
            return windows.Zip(windows.Skip(1), (a, b) => b > a ? 1 : 0).Sum();
        }
    }
}