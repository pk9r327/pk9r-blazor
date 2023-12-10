namespace Pk9r.Blazor.Minesweeper.Components;

/// <summary>
/// Interface for defining the game mode in Minesweeper.
/// </summary>
public interface IGameMode
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
}
