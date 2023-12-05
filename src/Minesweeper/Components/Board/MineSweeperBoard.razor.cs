using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Pk9r.Minesweeper.Components;
public partial class MinesweeperBoard
{
    [Parameter]
    public int Width { get; set; } = 16;

    [Parameter]
    public int Height { get; set; } = 16;

    private void OnContextMenu(MouseEventArgs mouseEventArgs)
    {
        
    }
}