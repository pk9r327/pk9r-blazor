using Pk9r.Minesweeper.Components.Extensions;

namespace Pk9r.Minesweeper.Components;
public class GameState
{
    public IGameMode GameModeInstance { get; private set; } = default!;

    public CellState[] CellStates { get; private set; } = default!;

    public List<CellState> MineCells { get; private set; } = [];

    public GameStatus GameStatus { get; set; }

    public Face Face { get; set; } = Face.SmileFace;

    public CellState? HoveredCell { get; set; }

    public bool IsFocusCell { get; set; }

    public int MinesNotFlagged { get; private set; }

    public event Action? OnChange;

    public GameState()
    {
        NewGame(GameMode.Expert);
    }

    public void NewGame(IGameMode gameMode)
    {
        GameModeInstance = gameMode;
        NewGame();
    }

    public void NewGame()
    {
        Initialize();
        GameStatus = GameStatus.AwaitingFirstMove;
        NotifyStateHasChanged();
    }

    public void MakeMove(int x, int y)
    {
        if (IsInvalidMove())
        {
            return;
        }

        if (GameStatus == GameStatus.AwaitingFirstMove)
        {
            SetMines(x, y);
            GameStatus = GameStatus.InProgress;
        }

        RevealCell(x, y);
    }

    private void RevealCell(int x, int y)
    {
        var currentCell = GetCellState(x, y);
        currentCell.Reveal();

        if (currentCell.IsMine)
        {
            //Timer.Stop();
            GameStatus = GameStatus.Defeated;
            RevealAllMines();
            currentCell.IsDeathMine = true;
        }
        else
        {
            if (currentCell.AdjacentMines == 0)
            {
                RevealZeros(x, y);
            }

            CheckForCompletion();
        }
    }

    private void RevealAllMines()
    {
        foreach (var mineCell in MineCells)
            mineCell.IsRevealed = true;
    }

    private void RevealZeros(int x, int y)
    {
        var neighborCells = GetNeighbors(x, y)
            .Where(cell => cell.IsRevealed == false);

        foreach (var neighbor in neighborCells)
        {
            neighbor.IsRevealed = true;

            if (neighbor.AdjacentMines == 0)
            {
                RevealZeros(neighbor.X, neighbor.Y);
            }
        }
    }

    private void Initialize()
    {
        int height = GameModeInstance.Height;
        int width = GameModeInstance.Width;

        var cellStates = new CellState[width * height];

        int count = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var cellState = new CellState(x, y);
                cellState.OnMouseUp = (e) => MinesweeperBoard.HandleCellMouseUp(e, this, cellState);
                cellState.OnMouseDown = (e) => MinesweeperBoard.HandleCellMouseDown(e, this, cellState);
                cellState.OnMouseOut = (e) => MinesweeperBoard.HandleCellMouseOut(e, this, cellState);
                cellState.OnMouseOver = (e) => MinesweeperBoard.HandleCellMouseOver(e, this, cellState);
                cellStates[count++] = cellState;
            }
        }

        CellStates = cellStates;
        MinesNotFlagged = GameModeInstance.Mines;
    }

    public void SetMines(int xFirstMove, int yFirstMove)
    {
        var mineCells = Random.Shared.TakeRandom(CellStates, GameModeInstance.Mines + 9);

        MineCells.Clear();

        int count = 0;
        int index = 0;
        while (count < GameModeInstance.Mines)
        {
            var cell = mineCells.ElementAt(index++);

            if ((cell.X >= xFirstMove - 1 && cell.X <= xFirstMove + 1) &&
                (cell.Y >= yFirstMove - 1 && cell.Y <= yFirstMove + 1))
            {
                continue;
            }

            cell.IsMine = true;

            var neighbors = GetNeighbors(cell.X, cell.Y);
            foreach (var neighbor in neighbors)
            {
                neighbor.AdjacentMines++;
            }
            MineCells.Add(cell);
            count++;
        }
    }

    private void CheckForCompletion()
    {
        //var unrevealedCells = Grid.get
        //    .Where(cell => !cell.IsRevealed)
        //    .Select(cell => cell.Id);

        //var mineCells = Grid
        //    .Where(cell => cell.IsMine)
        //    .Select(cell => cell.Id);

        //var existUnrevealedCellsWithoutMines = unrevealedCells.Except(mineCells).Any();

        //if (!existUnrevealedCellsWithoutMines)
        //{
        //    GameStatus = GameStatus.Victory;
        //    FlagAllMinesById(mineCells);
        //    //Timer.Stop();
        //}
    }

    //private void FlagAllMinesById(IEnumerable<Guid> cellIdentifiers)
    //{
    //    foreach (var id in cellIdentifiers)
    //    {
    //        var mineCell = GetCell(id);
    //        if (mineCell != null)
    //            mineCell.IsFlagged = true;
    //    }
    //}

    private List<CellState> GetNeighbors(int x, int y)
    {
        List<CellState> neighbors = [];

        for (int neighborX = x - 1; neighborX <= x + 1; neighborX++)
        {
            for (int neighborY = y - 1; neighborY <= y + 1; neighborY++)
            {
                if (neighborX >= 0 && neighborX < GameModeInstance.Width &&
                    neighborY >= 0 && neighborY < GameModeInstance.Height &&
                    (neighborX != x || neighborY != y))
                {
                    var neighbor = GetCellState(neighborX, neighborY);
                    neighbors.Add(neighbor);
                }
            }
        }

        return neighbors;
    }

    public CellState GetCellState(int x, int y)
    {
        return CellStates[GameModeInstance.Width * y + x];
    }

    public void RevealAllCells()
    {
        foreach (var cell in CellStates)
        {
            cell.IsRevealed = true;
        }
        NotifyStateHasChanged();
    }

    private bool IsInvalidMove()
    {
        if (GameStatus == GameStatus.Victory || GameStatus == GameStatus.Defeated)
        {
            return true;
        }

        //if (MinesNotFlagged == 0)
        //{
        //    return true;
        //}

        return false;
    }

    public void NotifyStateHasChanged()
    {
        OnChange?.Invoke();
    }
}
