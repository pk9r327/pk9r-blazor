using System.ComponentModel;

namespace Pk9r.Blazor.Minesweeper.Components;

/// <summary>
/// Represents the different faces that can be displayed in the game.
/// </summary>
public enum Face
{
    /// <summary>
    /// Represents the face displayed when a cell is clicked.
    /// </summary>
    [Description("clickface")]
    ClickFace,

    /// <summary>
    /// Represents the face displayed when the game is lost.
    /// </summary>
    [Description("lostface")]
    LostFace,

    /// <summary>
    /// Represents the default smiling face.
    /// </summary>
    [Description("smileface")]
    SmileFace,

    /// <summary>
    /// Represents the face displayed when a cell is clicked and held down.
    /// </summary>
    [Description("smilefacedown")]
    SmileFaceDown,

    /// <summary>
    /// Represents the face displayed when the game is won.
    /// </summary>
    [Description("winface")]
    WinFace,
}
