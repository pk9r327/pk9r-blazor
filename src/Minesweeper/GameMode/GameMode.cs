namespace Pk9r.Minesweeper.Components;

/// <summary>
/// Represents the game modes in Minesweeper.
/// </summary>
public static class GameMode
{
    /// <summary>
    /// Gets the beginner game mode.
    /// </summary>
    public static BeginnerGameMode Beginner { get; } = new BeginnerGameMode();

    /// <summary>
    /// Gets the intermediate game mode.
    /// </summary>
    public static IntermediateGameMode Intermediate { get; } = new IntermediateGameMode();

    /// <summary>
    /// Gets the expert game mode.
    /// </summary>
    public static ExpertGameMode Expert { get; } = new ExpertGameMode();
}
