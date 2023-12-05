namespace Pk9r.Minesweeper.Components;

/// <summary>
/// Represents a custom game mode in the Minesweeper game.
/// </summary>
public class CustomGameMode : IGameMode
{
    /// <summary>
    /// Gets or sets the width of the game board.
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Gets or sets the height of the game board.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Gets or sets the number of mines on the game board.
    /// </summary>
    public int Mines { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomGameMode"/> class using an existing game mode.
    /// </summary>
    /// <param name="gameMode">The game mode to copy settings from.</param>
    public CustomGameMode(IGameMode gameMode)
    {
        Width = gameMode.Width;
        Height = gameMode.Height;
        Mines = gameMode.Mines;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomGameMode"/> class with specified settings.
    /// </summary>
    /// <param name="width">The width of the game board.</param>
    /// <param name="height">The height of the game board.</param>
    /// <param name="mines">The number of mines on the game board.</param>
    public CustomGameMode(int width, int height, int mines)
    {
        Width = width;
        Height = height;
        Mines = mines;
    }
}
