namespace Dosuku;

public class SudokuBoard
{
    public int[,] Grid { get; private set; } = new int[9, 9];

    public void Display()
    {
        for (int i = 0; i < 9; i++)
        {
            if (i % 3 == 0 && i != 0)
            {
                Console.WriteLine("------+-------+------");
            }

            for (int j = 0; j < 9; j++)
            {
                if (j % 3 == 0 && j != 0)
                {
                    Console.Write("| ");
                }
                Console.Write(Grid[i, j] == 0 ? ". " : $"{Grid[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    public bool PlaceNumber(int row, int col, int num)
    {
        Grid[row, col] = num;
        return true;
    }

    public bool IsEmpty(int row, int col) => Grid[row, col] == 0;
}