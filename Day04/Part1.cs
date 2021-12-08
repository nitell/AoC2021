using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace AoC2021.Day04
{
    internal class Part1
    {
        public int Solve()
        {
            var input = File.ReadAllLines(@"Day04/input.txt");
            var numbers = input.First().Split(',').Select(s => int.Parse(s)).ToArray();

            var boards = new List<BingoBoard>();
            var boardStrings = input.Skip(2);
            while (boardStrings.Any(s=>s != string.Empty))
            {
                boards.Add(new BingoBoard(boardStrings.Take(5).ToArray()));
                boardStrings = boardStrings.Skip(6);

            }

            BingoBoard winner = null;
            IEnumerable<int> pulledNumbers = null;
            var round = 1;
            while (winner == null)
            {
                pulledNumbers = numbers.Take(round).ToArray();
                winner = boards.FirstOrDefault(b => b.IsBingo(pulledNumbers));
                round++;
            }

            return winner.CalculateThing(pulledNumbers) * pulledNumbers.Last();
        }

    }
}

internal class BingoBoard
{
    private int[][] _rows;
    private int[][] _columns;

    public BingoBoard(string[] input)
    {
        _rows = new int[5][];
        _rows = input.Select(s => s.Split(' ').Where(s => s != String.Empty).Select(s => int.Parse(s)).ToArray()).ToArray();
        _columns = Enumerable.Range(0, 5).Select(y => Enumerable.Range(0,5).Select(x=>_rows[x][y]).ToArray()).ToArray();
    }

    public bool IsBingo(IEnumerable<int> numbers)
    {
        return _rows.Any(r => r.All(n => numbers.Contains(n))) || _columns.Any(r => r.All(n => numbers.Contains(n)));
    }

    public int CalculateThing(IEnumerable<int> pulledNumbers)
    {
        return _rows.SelectMany(r => r).Where(i => !pulledNumbers.Contains(i)).Sum();
    }
}