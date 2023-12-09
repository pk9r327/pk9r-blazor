using Microsoft.AspNetCore.Components.Web;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components.Utilities;

namespace Pk9r.Minesweeper.Components;

/// <summary>
/// Represents the face of the Minesweeper game.
/// </summary>
public partial class MinesweeperFace : IDisposable
{
    /// <summary>
    /// Constant value for the left mouse button.
    /// </summary>
    public const int LeftMouseButton = 0;

    /// <summary>
    /// Indicates whether the face is in focus.
    /// </summary>
    private bool _isFocus = false;

    /// <summary>
    /// Gets the CSS class value for the face.
    /// </summary>
    protected string? ClassValue => new CssBuilder(Class)
        .AddClass("face")
        .AddClass(GameState.Face.ToAttributeValue())
        .Build();

    protected override void OnInitialized()
    {
        GameState.OnChange += StateHasChanged;
    }

    public void Dispose()
    {
        GameState.OnChange -= StateHasChanged;
    }

    /// <summary>
    /// Handles the onmousedown event. Changes the face to SmileFaceDown when the left mouse button is pressed.
    /// </summary>
    protected void HandleMouseDown(MouseEventArgs mouseEventArgs)
    {
        if (mouseEventArgs.Button == LeftMouseButton)
        {
            _isFocus = true;
            GameState.Face = Face.SmileFaceDown;
        }
    }

    /// <summary>
    /// Handles the onmouseup event. Changes the face back to SmileFace and starts a new game when the mouse button is released.
    /// </summary>
    protected void HandleMouseUp()
    {
        if (_isFocus)
        {
            _isFocus = false;
            GameState.Face = Face.SmileFace;

            GameState.NewGame();
        }
    }

    /// <summary>
    /// Handles the mouseout event. Changes the face back to SmileFace when the mouse leaves the face area.
    /// </summary>
    protected void HandleMouseOut(MouseEventArgs mouseEventArgs)
    {
        if (_isFocus)
        {
            _isFocus = false;
            GameState.Face = Face.SmileFace;
        }
    }
}
