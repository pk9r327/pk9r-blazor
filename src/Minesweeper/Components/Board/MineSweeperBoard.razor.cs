using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Pk9r.Minesweeper.Components;
public partial class MinesweeperBoard
{
    public int Width => GameState.GameModeInstance.Width;

    public int Height => GameState.GameModeInstance.Height;

    [Parameter]
    public GameState GameState { get; set; } = new();

    private void OnContextMenu(MouseEventArgs mouseEventArgs)
    {
        
    }
}