namespace Dosuku;

public class RowValidator : NumberValidator
{
    public override bool Validate(SudokuBoard board, int row, int col, int num)
    {
        for (int i = 0; i < 9; i++)
        {
            if (board.Grid[row, i] == num)
            {
                return false;
            }
        }
        return Next(board, row, col, num);
    }
}