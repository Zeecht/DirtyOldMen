using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace PathFindingProject
{
    partial class AStar
    {
        private Cell currentCell;
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
            // start calculations
            while (Lists.OpenList.Count > 0)
            {
                CheckLowestFVal();
                if (isGoal(currentCell))
                {
                    break;
                }
                CalculateSorundingCells(currentCell);

            }

            //returns the closed list to the caller
            return Lists.ClosedList;
        }
        private void CheckLowestFVal()
        {
            Cell currentLowest = null;
            foreach (Cell cell in Lists.OpenList)
            {
                if ( currentLowest == null || cell.FX < currentLowest.FX && !Lists.BlockedList.Contains(cell))
                {
                    currentLowest = cell;
                }
            }
            Lists.OpenList.Remove(currentLowest);
            currentCell = currentLowest;
        }

        private void CalculateSorundingCells(Cell checkCell)
        {
            Cell cellToCheck;
            // Get W Cell
            cellToCheck = GetCellFromPos(checkCell.X + checkCell.Rect.Width, checkCell.Y);
            SetCell(cellToCheck, false);
            // Get E Cell
            cellToCheck = GetCellFromPos(checkCell.X - checkCell.Rect.Width, checkCell.Y);
            SetCell(cellToCheck, false);
            // Get N Cell
            cellToCheck = GetCellFromPos(checkCell.X, checkCell.Y - checkCell.Rect.Height);
            SetCell(cellToCheck, false);
            // Get S Cell
            cellToCheck = GetCellFromPos(checkCell.X, checkCell.Y + checkCell.Rect.Height);
            SetCell(cellToCheck, false);
            // Get SE Cell
            cellToCheck = GetCellFromPos(checkCell.X - checkCell.Rect.Width, checkCell.Y + checkCell.Rect.Height);
            SetCell(cellToCheck, true);
            // Get SW Cell
            cellToCheck = GetCellFromPos(checkCell.X + checkCell.Rect.Width, checkCell.Y + checkCell.Rect.Height);
            SetCell(cellToCheck, true);
            // Get NE Cell
            cellToCheck = GetCellFromPos(checkCell.X - checkCell.Rect.Width, checkCell.Y - checkCell.Rect.Height);
            SetCell(cellToCheck, true);
            // Get NW Cell
            cellToCheck = GetCellFromPos(checkCell.X + checkCell.Rect.Width, checkCell.Y - checkCell.Rect.Height);
            SetCell(cellToCheck, true);
        }


        private void SetCell(Cell cellToSet, bool isDiagonal)
        {
            if (cellToSet != null || Lists.OpenList.Contains(cellToSet))
            {
                if (isDiagonal)
                {
                    cellToSet.GX = 14;
                }
                else
                {
                    cellToSet.GX = 10;
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
                if (item.Rect.Contains(new Point(x,y)))
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
