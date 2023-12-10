using Microsoft.AspNetCore.Components.Web;

namespace Pk9r.Blazor.Minesweeper.Components;
public partial class MinesweeperBoard : IDisposable
{
    public int Width => GameState.GameModeInstance.Width;

    public int Height => GameState.GameModeInstance.Height;

    internal static void HandleCellMouseUp(MouseEventArgs mouseEventArgs, GameState gameState, CellState cellState)
    {
        if (mouseEventArgs.Button == 0)
        {
            gameState.Face = Face.SmileFace;
            gameState.IsFocusCell = false;
            if (!cellState.IsFlagged)
            {
                gameState.MakeMove(cellState.X, cellState.Y);

            }
            gameState.NotifyStateHasChanged();
        }
    }

    internal static void HandleCellMouseDown(MouseEventArgs mouseEventArgs, GameState gameState, CellState cellState)
    {
        if (mouseEventArgs.Button == 0)
        {
            gameState.Face = Face.ClickFace;
            gameState.IsFocusCell = true;
            gameState.NotifyStateHasChanged();
        }

        if (mouseEventArgs.Buttons == 2)
        {
            cellState.Flag();
        }
    }

    internal static void HandleCellMouseOut(MouseEventArgs mouseEventArgs, GameState gameState, CellState cellState)
    {
        if (gameState.HoveredCell == cellState)
        {
            gameState.HoveredCell = null;
        }
    }

    internal static void HandleCellMouseOver(MouseEventArgs mouseEventArgs, GameState gameState, CellState cellState)
    {
        if (gameState.HoveredCell != cellState)
        {
            gameState.HoveredCell = cellState;
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