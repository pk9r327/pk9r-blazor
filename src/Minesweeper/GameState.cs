﻿using Pk9r.Minesweeper.Components.Extensions;

namespace Pk9r.Minesweeper.Components;
public class GameState
{
    public IGameMode GameModeInstance { get; set; } = GameMode.Expert;

    public CellState[] CellStates { get; set; }

    public GameStatus GameStatus { get; set; }

    public int MinesNotFlagged { get; private set; }

    public GameState()
    {
        int height = GameModeInstance.Height;
        int width = GameModeInstance.Width;

        var cellStates = new CellState[width * height];

        int count = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                cellStates[count++] = new CellState(x, y);
            }
        }

        CellStates = cellStates;
        MinesNotFlagged = GameModeInstance.Mines;
        GameStatus = GameStatus.AwaitingFirstMove;
    }

    public void FirstMove(int x, int y)
    {
        GameStatus = GameStatus.InProgress;
    }

    public void SetMines(int xFirstMove, int yFirstMove)
    {
        var mineCells = Random.Shared.TakeRandom(CellStates, GameModeInstance.Mines + 9);

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
}