using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2021.Day02
{
    internal class Part1
    {
        public int Solve()
        {
            var commands = new Dictionary<string, Action<State, int>>
            {
                {"forward", (s, i) => s.Position += i},
                {"up", (s, i) => s.Depth -= i},
                {"down", (s, i) => s.Depth += i}
            };
            var state = new State();
            var input = File.ReadAllLines(@"Day02/input.txt").Select(s => s.Split(" "));
            foreach (var inp in input) commands[inp[0]](state, int.Parse(inp[1]));

            return state.Depth * state.Position;
        }

        public class State
        {
            public int Depth { get; set; }
            public int Position { get; set; }
        }
    }
}