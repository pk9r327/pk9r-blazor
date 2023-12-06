using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components.Utilities;

namespace Pk9r.Minesweeper.Components;

/// <summary>
/// Represents the face of the Minesweeper game.
/// </summary>
public partial class MinesweeperFace
{
    public const int LeftMouseButton = 0;

    bool _isFocus = false;

    /// <summary>
    /// Gets the CSS class value for the face.
    /// </summary>
    protected string? ClassValue => new CssBuilder(Class)
        .AddClass("face")
        .AddClass(Face.ToAttributeValue())
        .Build();

    /// <summary>
    /// Gets or sets the face of the Minesweeper game.
    /// </summary>
    [Parameter]
    public Face Face { get; set; } = Face.SmileFace;

    [Parameter]
    public GameState GameState { get; set; }

    /// <summary>
    /// Handles the onmousedown event.
    /// </summary>
    protected void HandleMouseDown(MouseEventArgs mouseEventArgs)
    {
        if (mouseEventArgs.Button == LeftMouseButton)
        {
            _isFocus = true;
            Face = Face.SmileFaceDown;
        }
    }

    /// <summary>
    /// Handles the onmouseup event.
    /// </summary>
    protected void HandleMouseUp(MouseEventArgs mouseEventArgs)
    {
        if (_isFocus)
        {
            Face = Face.SmileFace;
        }
    }

    protected void HandleMouseOut(MouseEventArgs mouseEventArgs)
    {
        if (_isFocus)
        {
            Face = Face.SmileFace;
        }
    }
}
