using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security;
using Microsoft.VisualBasic.CompilerServices;

namespace AoC2021.Day04
{
    internal class Part2
    {
        public int Solve()
        {
            var input = File.ReadAllLines(@"Day04/input.txt");
            var numbers = input.First().Split(',').Select(s => int.Parse(s)).ToArray();

            var boards = new List<BingoBoard>();
            var boardStrings = input.Skip(2);
            while (boardStrings.Any(s => s != string.Empty))
            {
                boards.Add(new BingoBoard(boardStrings.Take(5).ToArray()));
                boardStrings = boardStrings.Skip(6);

            }

            BingoBoard lastWinner = null;
            IEnumerable<int> pulledNumbers = null;
            var round = 1;
            while (boards.Any())
            {
                pulledNumbers = numbers.Take(round).ToArray();
                var winners = boards.Where(b => b.IsBingo(pulledNumbers));
                lastWinner = winners.Count() == 1 ? winners.First() : null;
                boards = boards.Except(winners).ToList();
                round++;
            }

            return lastWinner.CalculateThing(pulledNumbers) * pulledNumbers.Last();
        }
    }
}