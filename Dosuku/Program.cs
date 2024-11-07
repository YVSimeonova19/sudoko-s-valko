using System;

namespace Dosuku;

class Program
{
    static void Main(string[] args)
    {
        SudokuGenerator generator = new SudokuGenerator();
        SudokuBoard board = generator.GenerateBoard();

        Console.WriteLine("Initial board:");
        board.Display();

        SudokuSolver solver = new SudokuSolver();
        if (solver.Solve(board))
        {
            Console.WriteLine("\nSolved board:");
            board.Display();
        }
        else
        {
            Console.WriteLine("No solution");
        }
    }
}
