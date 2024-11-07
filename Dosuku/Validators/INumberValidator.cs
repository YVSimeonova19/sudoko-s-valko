namespace Dosuku;

public interface INumberValidator
{
    void SetNextValidator(INumberValidator nextValidator);

    bool Next(SudokuBoard board, int row, int col, int num);
    bool Validate(SudokuBoard board, int row, int col, int num);
}
