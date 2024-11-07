namespace Dosuku;

public class NumberFactory : INumberGeneratorFactory
{
    private NumberValidator validatorChain;

    public NumberFactory()
    {
        validatorChain = new RowValidator();
        NumberValidator columnValidator = new ColumnValidator();
        NumberValidator subgridValidator = new SubgridValidator();

        validatorChain.SetNextValidator(columnValidator);
        columnValidator.SetNextValidator(subgridValidator);
    }
        
    public int GenerateValidNumber(SudokuBoard board, int row, int col)
    {
        Random random = new Random();
        int attempts = 0;

        while (attempts < 9)
        {
            int num = random.Next(1, 10);
            if (validatorChain.Validate(board, row, col, num))
            {
                return num;
            }
            attempts++;
        }

        return 0;
    }

    public bool IsValid(SudokuBoard board, int row, int col, int num)
    {
        return validatorChain.Validate(board, row, col, num);
    }
}