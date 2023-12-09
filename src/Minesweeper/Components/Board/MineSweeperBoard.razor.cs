using Microsoft.AspNetCore.Components.Web;

namespace Pk9r.Minesweeper.Components;
public partial class MinesweeperBoard : IDisposable
{
    public int Width => GameState.GameModeInstance.Width;

    public int Height => GameState.GameModeInstance.Height;

    public static void HandleCellMouseUp(MouseEventArgs mouseEventArgs, GameState gameState, CellState cellState)
    {
        if (mouseEventArgs.Button == 0)
        {
            gameState.Face = Face.SmileFace;
            if (!cellState.IsFlagged)
            {
                gameState.MakeMove(cellState.X, cellState.Y);

            }
            gameState.NotifyStateHasChanged();
        }
    }

    public static void HandleCellMouseDown(MouseEventArgs mouseEventArgs, GameState gameState, CellState cellState)
    {
        if (mouseEventArgs.Button == 0)
        {
            gameState.Face = Face.ClickFace;
            gameState.NotifyStateHasChanged();
        }

        if (mouseEventArgs.Buttons == 2)
        {
            cellState.Flag();
        }
    }

    protected override void OnInitialized()
    {
        GameState.OnChange += StateHasChanged;
    }

    public void Dispose()
    {
        GameState.OnChange -= StateHasChanged;
    }
}