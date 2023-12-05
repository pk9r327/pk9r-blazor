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

    /// <summary>
    /// Handles the onmousedown event.
    /// </summary>
    protected void HandleMouseDown(MouseEventArgs mouseEventArgs)
    {
        if (mouseEventArgs.Button == LeftMouseButton)
        {
            Face = Face.SmileFaceDown;
        }
    }

    /// <summary>
    /// Handles the onmouseup event.
    /// </summary>
    protected void HandleMouseUp(MouseEventArgs mouseEventArgs)
    {
        Face = Face.SmileFace;
    }

    protected void HandleMouseOut(MouseEventArgs mouseEventArgs)
    {
        Face = Face.SmileFace;
    }
}
