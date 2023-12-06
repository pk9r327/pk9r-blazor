using Microsoft.AspNetCore.Components.Web;

namespace Pk9r.Minesweeper.Components;
public partial class MinesweeperBoard : IDisposable
{
    public int Width => GameState.GameModeInstance.Width;

    public int Height => GameState.GameModeInstance.Height;

    protected override void OnInitialized()
    {
        GameState.OnChange += StateHasChanged;
    }

    private void OnContextMenu(MouseEventArgs mouseEventArgs)
    {

    }

    public void Dispose()
    {
        GameState.OnChange -= StateHasChanged;
    }
}