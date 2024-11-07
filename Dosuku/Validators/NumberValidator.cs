namespace Dosuku;

public abstract class NumberValidator : INumberValidator
{
    protected INumberValidator NextValidator;

    public void SetNextValidator(INumberValidator validator)
    {
        NextValidator = validator;
    }

    public abstract bool Validate(SudokuBoard board, int row, int col, int num);

    public bool Next(SudokuBoard board, int row, int col, int num)
    {
        return NextValidator == null || NextValidator.Validate(board, row, col, num);
    }
}