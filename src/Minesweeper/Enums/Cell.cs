using System.ComponentModel;

namespace Pk9r.Minesweeper.Components;

/// <summary>
/// Represents the different types of cells in a Minesweeper game.
/// </summary>
public enum Cell
{
    /// <summary>
    /// Represents a cell that has been blasted.
    /// </summary>
    [Description("blast")]
    Blast,

    /// <summary>
    /// Represents a cell with 1 adjacent mine.
    /// </summary>
    [Description("cell1")]
    Cell1,

    /// <summary>
    /// Represents a cell with 2 adjacent mines.
    /// </summary>
    [Description("cell2")]
    Cell2,

    /// <summary>
    /// Represents a cell with 3 adjacent mines.
    /// </summary>
    [Description("cell3")]
    Cell3,

    /// <summary>
    /// Represents a cell with 4 adjacent mines.
    /// </summary>
    [Description("cell4")]
    Cell4,

    /// <summary>
    /// Represents a cell with 5 adjacent mines.
    /// </summary>
    [Description("cell5")]
    Cell5,

    /// <summary>
    /// Represents a cell with 6 adjacent mines.
    /// </summary>
    [Description("cell6")]
    Cell6,

    /// <summary>
    /// Represents a cell with 7 adjacent mines.
    /// </summary>
    [Description("cell7")]
    Cell7,

    /// <summary>
    /// Represents a cell with 8 adjacent mines.
    /// </summary>
    [Description("cell8")]
    Cell8,

    /// <summary>
    /// Represents a cell that is down.
    /// </summary>
    [Description("celldown")]
    CellDown,

    /// <summary>
    /// Represents a cell that has been flagged.
    /// </summary>
    [Description("cellflag")]
    CellFlag,

    /// <summary>
    /// Represents a cell that contains a mine.
    /// </summary>
    [Description("cellmine")]
    CellMine,

    /// <summary>
    /// Represents a cell that is up.
    /// </summary>
    [Description("cellup")]
    CellUp,

    /// <summary>
    /// Represents a cell that has been falsely flagged as a mine.
    /// </summary>
    [Description("falsemine")]
    FalseMine,

}
