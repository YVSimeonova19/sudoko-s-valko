namespace Dosuku;

public interface INumberGeneratorFactory
{
    int GenerateValidNumber(SudokuBoard board, int row, int col);
    bool IsValid(SudokuBoard board, int row, int col, int num);
}