namespace Dosuku;

public class SubgridValidator : NumberValidator
{
    public override bool Validate(SudokuBoard board, int row, int col, int num)
    {
        int startRow = row / 3 * 3;
        int startCol = col / 3 * 3;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board.Grid[startRow + i, startCol + j] == num) return false;
            }
        }
        return Next(board, row, col, num);
    }
}