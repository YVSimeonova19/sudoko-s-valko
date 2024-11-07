namespace Dosuku;

public class SudokuSolver
{
    private NumberFactory numberFactory;

    public SudokuSolver()
    {
        numberFactory = new NumberFactory();
    }

    public bool Solve(SudokuBoard board)
    {
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                if (board.IsEmpty(row, col))
                {
                    for (int num = 1; num <= 9; num++)
                    {
                        if (numberFactory.IsValid(board, row, col, num))
                        {
                            board.PlaceNumber(row, col, num);

                            if (Solve(board)) 
                            {
                                return true;
                            }

                            board.PlaceNumber(row, col, 0); 
                        }
                    }
                    return false; 
                }
            }
        }
        return true; 
    }
}