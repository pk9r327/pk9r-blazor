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
    /// Gets or sets the face of the Minesweeper game.
    /// </summary>
    private Face _face = Face.SmileFace;

    /// <summary>
    /// Gets the CSS class value for the face.
    /// </summary>
    protected string? ClassValue => new CssBuilder(Class)
        .AddClass("face")
        .AddClass(_face.ToAttributeValue())
        .Build();

    //[Parameter]
    //public EventCallback<GameState> GameStateChanged { get; set; }

    /// <summary>
    /// Handles the onmousedown event.
    /// </summary>
    protected void HandleMouseDown(MouseEventArgs mouseEventArgs)
    {
        if (mouseEventArgs.Button == LeftMouseButton)
        {
            _isFocus = true;
            _face = Face.SmileFaceDown;
        }
    }

    /// <summary>
    /// Handles the onmouseup event.
    /// </summary>
    protected void HandleMouseUp()
    {
        if (_isFocus)
        {
            _isFocus = false;
            _face = Face.SmileFace;

            GameState.NewGame();
        }
    }

    protected void HandleMouseOut(MouseEventArgs mouseEventArgs)
    {
        if (_isFocus)
        {
            _isFocus = false;
            _face = Face.SmileFace;
        }
    }
}
