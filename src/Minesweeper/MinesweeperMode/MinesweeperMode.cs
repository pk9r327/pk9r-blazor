namespace Pk9r.Blazor.Minesweeper.Components;

/// <summary>
/// Represents the game modes in Minesweeper.
/// </summary>
public static class MinesweeperMode
{
    /// <summary>
    /// Gets the beginner game mode.
    /// </summary>
    public static BeginnerMinesweeperMode Beginner { get; } = new BeginnerMinesweeperMode();

    /// <summary>
    /// Gets the intermediate game mode.
    /// </summary>
    public static IntermediateMinesweeperMode Intermediate { get; } = new IntermediateMinesweeperMode();

    /// <summary>
    /// Gets the expert game mode.
    /// </summary>
    public static ExpertMinesweeperMode Expert { get; } = new ExpertMinesweeperMode();
}
