namespace Pk9r.Blazor.Minesweeper.Components;

/// <summary>
/// Enum representing the status of a game.
/// </summary>
public enum GameStatus
{
    /// <summary>
    /// The game is awaiting the first move.
    /// </summary>
    AwaitingFirstMove,

    /// <summary>
    /// The game is currently in progress.
    /// </summary>
    InProgress,

    /// <summary>
    /// The game has ended in victory.
    /// </summary>
    Victory,

    /// <summary>
    /// The game has ended in defeat.
    /// </summary>
    Defeated
}
