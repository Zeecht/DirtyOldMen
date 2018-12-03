using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFindingProject
{
    partial class AStar
    {
        int gridLengthX = 10;
        int gridLengthY = 10;


        /// <summary>
        /// Mortens Astar path finding algorythm
        /// </summary>
        public void AstarPathfinding(Edge endPoint)
        {
            //Sets the hX(Distance to goal) value on the entire grid 
            SetHValue(endPoint);
            //Adds the startPosition to the openList
            Lists.OpenList.Add(Grid.Check);
            //The edge that is going to be checkeds saved position
            Edge edgeToBeChecked = null;

            while (Lists.OpenList.Count != 0)
            {
                //Checks for the lowest fX value in the openList
                //Removes it from the list and sets its value to "edgeToBeChecked"
                #region
                Edge lowestFValue = null;
                foreach (Edge e in Lists.OpenList)
                {
                    if (lowestFValue == null || e.FX < lowestFValue.FX)
                    {
                        lowestFValue = e;
                    }
                }
                Lists.OpenList.Remove(lowestFValue);
                edgeToBeChecked = lowestFValue;
                #endregion

                //Checks if the endpoint has bin reached
                #region
                if (edgeToBeChecked == endPoint)
                {
                    break;
                }
                #endregion

                //Calls the method that finds the nearest 8 edges of the checked edge,
                //and sets their parent, gX and fX
                #region
                FindNearestEightEdges(edgeToBeChecked);
                #endregion


                Lists.ClosedList.Add(edgeToBeChecked);
                Grid.Check = edgeToBeChecked;
            }
        }


        public void FindNearestEightEdges(Edge checkedEdge)
        {
            //Find the index of the value we check
            int index = Grid.GridPoints.IndexOf(checkedEdge);
            //x value of the edge we are checking
            var x = checkedEdge.X;
            //y value of the edge we are checking
            var y = checkedEdge.Y;

            //Checks if its at the side of the grid
            if (checkedEdge.X == 0 || checkedEdge.Y == 0 || checkedEdge.X == 9 || checkedEdge.Y == 9)
            {
                if (checkedEdge.X == 0 && checkedEdge.Y == 0)
                {
                    var t = Grid.GridPoints.ElementAt(index + 1);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                    
                    t = Grid.GridPoints.ElementAt(index + 10);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                    
                    t = Grid.GridPoints.ElementAt(index + 11);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 14;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                }
                else if (checkedEdge.X == 9 && checkedEdge.Y == 0)
                {
                    var t = Grid.GridPoints.ElementAt(index - 1);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }

                    t = Grid.GridPoints.ElementAt(index + 10);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }

                    t = Grid.GridPoints.ElementAt(index + 9);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 14;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                }
                else if (checkedEdge.X == 0 && checkedEdge.Y == 9)
                {
                    var t = Grid.GridPoints.ElementAt(index + 1);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }

                    t = Grid.GridPoints.ElementAt(index - 10);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }

                    t = Grid.GridPoints.ElementAt(index - 9);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 14;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                }
                else if (checkedEdge.X == 9 && checkedEdge.Y == 9)
                {
                    var t = Grid.GridPoints.ElementAt(index - 1);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                    
                    t = Grid.GridPoints.ElementAt(index - 10);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }

                    t = Grid.GridPoints.ElementAt(index - 11);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 14;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                }
                if (checkedEdge.X > 0 && checkedEdge.X < 9 && checkedEdge.Y == 0)
                {
                    var t = Grid.GridPoints.ElementAt(index - 1);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }

                    t = Grid.GridPoints.ElementAt(index + 1);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }

                    t = Grid.GridPoints.ElementAt(index + 10);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                    
                    t = Grid.GridPoints.ElementAt(index + 9);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 14;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                    
                    t = Grid.GridPoints.ElementAt(index + 11);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 14;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                }
                else if (checkedEdge.Y > 0 && checkedEdge.Y < 9 && checkedEdge.X == 0)
                {
                    var t = Grid.GridPoints.ElementAt(index - 10);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                    
                    t = Grid.GridPoints.ElementAt(index -9);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 14;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                    
                    t = Grid.GridPoints.ElementAt(index + 1);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                    
                    t = Grid.GridPoints.ElementAt(index + 11);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 14;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                    
                    t = Grid.GridPoints.ElementAt(index + 10);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                }
                else if (checkedEdge.X > 0 && checkedEdge.X < 9 && checkedEdge.Y == 9)
                {
                    var t = Grid.GridPoints.ElementAt(index -1);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }

                    t = Grid.GridPoints.ElementAt(index -11);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 14;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                    
                    t = Grid.GridPoints.ElementAt(index -9);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 14;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                    
                    t = Grid.GridPoints.ElementAt(index -10);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }

                    t = Grid.GridPoints.ElementAt(index +1);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                }
                else if (checkedEdge.Y > 9 && checkedEdge.Y < 0 && checkedEdge.X == 9)
                {
                    var t = Grid.GridPoints.ElementAt(index - 1);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }

                    t = Grid.GridPoints.ElementAt(index - 11);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 14;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                    
                    t = Grid.GridPoints.ElementAt(index - 10);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }

                    t = Grid.GridPoints.ElementAt(index - 9);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 14;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }

                    t = Grid.GridPoints.ElementAt(index + 1);
                    if (!Lists.OpenList.Contains(t))
                    {
                        t.Parrent = checkedEdge;
                        t.GX = 10;
                        t.FX = t.GX += t.HX;
                        Lists.OpenList.Add(t);
                    }
                }
            }
            else
            {
                var t = Grid.GridPoints.ElementAt(index - 11);
                if (!Lists.OpenList.Contains(t))
                {
                    t.Parrent = checkedEdge;
                    t.GX = 14;
                    t.FX = t.GX += t.HX;
                    Lists.OpenList.Add(t);
                }

                t = Grid.GridPoints.ElementAt(index - 10);
                if (!Lists.OpenList.Contains(t))
                {
                    t.Parrent = checkedEdge;
                    t.GX = 10;
                    t.FX = t.GX += t.HX;
                    Lists.OpenList.Add(t);
                }

                t = Grid.GridPoints.ElementAt(index - 9);
                if (!Lists.OpenList.Contains(t))
                {
                    t.Parrent = checkedEdge;
                    t.GX = 14;
                    t.FX = t.GX += t.HX;
                    Lists.OpenList.Add(t);
                }

                t = Grid.GridPoints.ElementAt(index + 1);
                if (!Lists.OpenList.Contains(t))
                {
                    t.Parrent = checkedEdge;
                    t.GX = 10;
                    t.FX = t.GX += t.HX;
                    Lists.OpenList.Add(t);
                }

                t = Grid.GridPoints.ElementAt(index + 11);
                if (!Lists.OpenList.Contains(t))
                {
                    t.Parrent = checkedEdge;
                    t.GX = 10;
                    t.FX = t.GX += t.HX;
                    Lists.OpenList.Add(t);
                }
                
                t = Grid.GridPoints.ElementAt(index + 10);
                if (!Lists.OpenList.Contains(t))
                {
                    t.Parrent = checkedEdge;
                    t.GX = 14;
                    t.FX = t.GX += t.HX;
                    Lists.OpenList.Add(t);
                }
                
                t = Grid.GridPoints.ElementAt(index + 9);
                if (!Lists.OpenList.Contains(t))
                {
                    t.Parrent = checkedEdge;
                    t.GX = 14;
                    t.FX = t.GX += t.HX;
                    Lists.OpenList.Add(t);
                }
                
                t = Grid.GridPoints.ElementAt(index - 1);
                if (!Lists.OpenList.Contains(t))
                {
                    t.Parrent = checkedEdge;
                    t.GX = 14;
                    t.FX = t.GX += t.HX;
                    Lists.OpenList.Add(t);
                }
            }
        }

        /// <summary>
        /// Sets all H value in the grid list.
        /// </summary>
        /// <param name="endPoint"></param>
        public void SetHValue(Edge endPoint)
        {
            foreach (Edge e in Grid.GridPoints)
            {
                e.HX = HeuristicCalculator(e, endPoint);
            }
        }
    }
}
