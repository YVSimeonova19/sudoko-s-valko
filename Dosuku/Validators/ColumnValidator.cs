namespace Dosuku;

 class ColumnValidator : NumberValidator
{
    public override bool Validate(SudokuBoard board, int row, int col, int num)
    {
        for (int i = 0; i < 9; i++)
        {
            if (board.Grid[i, col] == num)
            {
                return false;
            }
        }
        return Next(board, row, col, num);
    }
}