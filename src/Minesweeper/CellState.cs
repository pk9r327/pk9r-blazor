using Microsoft.AspNetCore.Components.Web;

namespace Pk9r.Blazor.Minesweeper.Components;

/// <summary>
/// Represents the state of a cell in a Minesweeper game.
/// </summary>
public class CellState(int x, int y)
{
    /// <summary>
    /// Unique identifier for the cell.
    /// </summary>
    public Guid Id { get; } = Guid.NewGuid();

    /// <summary>
    /// X-coordinate of the cell.
    /// </summary>
    public int X { get; } = x;

    /// <summary>
    /// Y-coordinate of the cell.
    /// </summary>
    public int Y { get; } = y;

    /// <summary>
    /// Indicates whether the cell contains a mine.
    /// </summary>
    public bool IsMine { get; set; } = false;

    /// <summary>
    /// Indicates whether the cell has been flagged by the player.
    /// </summary>
    public bool IsFlagged { get; set; } = false;

    /// <summary>
    /// Indicates whether the cell has been revealed by the player.
    /// </summary>
    public bool IsRevealed { get; set; } = false;

    /// <summary>
    /// Indicates whether the cell contains a mine that caused the player's death.
    /// </summary>
    public bool IsDeathMine { get; set; }

    /// <summary>
    /// The number of mines in the adjacent cells.
    /// </summary>
    public int AdjacentMines { get; set; } = 0;

    /// <summary>
    /// Flags or unflags the cell, if it has not been revealed.
    /// </summary>
    public void Flag()
    {
        if (!IsRevealed)
        {
            IsFlagged = !IsFlagged;
        }
    }

    /// <summary>
    /// Reveals the cell and unflags it.
    /// </summary>
    public void Reveal()
    {
        IsRevealed = true;
        IsFlagged = false;
    }

    public Action<MouseEventArgs> OnMouseUp { get; set; } = default!;

    public Action<MouseEventArgs> OnMouseDown { get; set; } = default!;

    public Action<MouseEventArgs> OnMouseOut { get; set; } = default!;

    public Action<MouseEventArgs> OnMouseOver { get; set; } = default!;
}
