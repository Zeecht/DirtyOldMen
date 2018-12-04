using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Threading;


namespace PathFindingProject
{
    partial class AStar
    {
        private Cell goal;
        public List<Cell> GetRoute(Cell goal)
        {
            //clears list before usage
            if (Lists.ClosedList.Count > 0)
            {
                ClearLists();
            }

            this.goal = goal;
            // set heuricstic for the grid
            SetHValue(goal);
            // add intial wizard point
            Lists.OpenList.Add(Grid.Check);

            Cell currentCell = Grid.Check;
            // start calculations
            while (Lists.OpenList.Count > 0)
            {
                currentCell = CheckLowestFVal();
                if (isGoal(currentCell))
                {
                    break;
                }
                CalculateSorundingCells(currentCell);

                Grid.Check = currentCell;
                Thread.Sleep(500);
            }

            //returns the closed list to the caller
            return Lists.ClosedList;
        }
        private Cell CheckLowestFVal()
        {
            Cell currentLowest = null;
            foreach (Cell cell in Lists.OpenList)
            {
                if (currentLowest == null || cell.FX < currentLowest.FX && !Lists.BlockedList.Contains(cell))
                {
                    currentLowest = cell;
                }
            }
            Lists.OpenList.Remove(currentLowest);
            return currentLowest;
        }

        private void CalculateSorundingCells(Cell checkCell)
        {

            // Get W Cell
            SetCell(checkCell, GetCellFromPos(checkCell.Rect.X + checkCell.Rect.Width, checkCell.Rect.Y), false);
            // Get E Cell
            SetCell(checkCell, GetCellFromPos(checkCell.Rect.X - checkCell.Rect.Width, checkCell.Rect.Y), false);
            // Get N Cell
            SetCell(checkCell, GetCellFromPos(checkCell.Rect.X, checkCell.Rect.Y - checkCell.Rect.Height), false);
            // Get S Cell
            SetCell(checkCell, GetCellFromPos(checkCell.Rect.X, checkCell.Rect.Y + checkCell.Rect.Height), false);
            // Get SE Cell
            SetCell(checkCell, GetCellFromPos(checkCell.Rect.X - checkCell.Rect.Width, checkCell.Rect.Y + checkCell.Rect.Height), true);
            // Get SW Cell
            SetCell(checkCell, GetCellFromPos(checkCell.Rect.X + checkCell.Rect.Width, checkCell.Rect.Y + checkCell.Rect.Height), true);
            // Get NE Cell
            SetCell(checkCell, GetCellFromPos(checkCell.Rect.X - checkCell.Rect.Width, checkCell.Rect.Y - checkCell.Rect.Height), true);
            // Get NW Cell
            SetCell(checkCell, GetCellFromPos(checkCell.Rect.X + checkCell.Rect.Width, checkCell.Rect.Y - checkCell.Rect.Height), true);

            Lists.ClosedList.Add(checkCell);
        }


        private void SetCell(Cell parrent, Cell cellToSet, bool isDiagonal)
        {
            if (cellToSet != null && !Lists.OpenList.Contains(cellToSet))
            {
                cellToSet.Parrent = parrent;
                if (isDiagonal)
                {
                    cellToSet.GX = 14 + parrent.GX;
                }
                else
                {
                    cellToSet.GX = 10 + parrent.GX;
                }
                cellToSet.FX = cellToSet.GX + cellToSet.HX;
                Lists.OpenList.Add(cellToSet);
            }
        }
        private Cell GetCellFromPos(int x, int y)
        {
            Cell returnCell = null;
            foreach (Cell item in Grid.GridPoints)
            {
                //if (item.Rect.X == x && item.Rect.Y == y)
                //{
                //    return item;
                //}
                if (item.Rect.Contains(new Point(x, y)))
                {
                    return item;
                }
            }
            return returnCell;
        }

        private bool isGoal(Cell cell)
        {
            if (cell == goal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void ClearLists()
        {
            Lists.ClosedList.Clear();
            Lists.OpenList.Clear();
        }
    }
}
