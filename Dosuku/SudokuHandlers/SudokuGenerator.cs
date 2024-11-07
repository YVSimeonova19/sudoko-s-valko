using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dosuku;

public class SudokuGenerator
{
    private NumberFactory numberFactory;

    public SudokuGenerator()
    {
        numberFactory = new NumberFactory();
    }
    
    public class SudokuData
    {
        [JsonPropertyName("newboard")]
        public NewBoardData NewBoard { get; set; }
    }

    public class NewBoardData
    {
        [JsonPropertyName("grids")]
        public GridData[] Grids { get; set; }
    }

    public class GridData
    {
        [JsonPropertyName("value")]
        public int[][] Value { get; set; }
    }

    public SudokuBoard LoadBoardFromJson(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        SudokuData sudokuData = JsonSerializer.Deserialize<SudokuData>(jsonString);
        SudokuBoard board = new SudokuBoard();

        if (sudokuData?.NewBoard?.Grids != null && sudokuData.NewBoard.Grids.Length > 0)
        {
            int[][] jaggedGridData = sudokuData.NewBoard.Grids[0].Value;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board.PlaceNumber(i, j, jaggedGridData[i][j]);
                }
            }
        }
        return board;
    }

    public SudokuBoard GenerateBoard()
    {
        SudokuBoard board = new SudokuBoard();
        string filepath = "Boards/SudokuBoard.json"; 

        try
        {
            board = this.LoadBoardFromJson(filepath);
            Console.WriteLine("JSON loaded");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Couldnt find the file path: {filepath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }

        return board;
    }
}