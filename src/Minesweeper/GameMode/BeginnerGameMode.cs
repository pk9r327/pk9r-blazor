namespace Pk9r.Blazor.Minesweeper.Components;

public class BeginnerGameMode : IGameMode
{
    /// <summary>
    /// Gets the width of the game board.
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// Gets the height of the game board.
    /// </summary>
    public int Height { get; }

    /// <summary>
    /// Gets the number of mines on the game board.
    /// </summary>
    public int Mines { get; }

    /// <summary>
    /// Initializes a new instance of the BeginnerGameMode class.
    /// </summary>
    public BeginnerGameMode()
    {
        Width = 9;
        Height = 9;
        Mines = 10;
    }
}
