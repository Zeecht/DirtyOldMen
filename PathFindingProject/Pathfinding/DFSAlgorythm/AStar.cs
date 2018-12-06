using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PathFindingProject
{
    partial class AStar
    {
        //Mortens DFS Algoritme
        public static Graph graph = new Graph();
        public void Start(Edge start)
        {
            SetData();
            IEnumerable<Edge> data = Grid.GridPoints;

            Console.WriteLine("Top Key");
            DFS(81, 11);
            Console.WriteLine("Tree house");
            DFS(11, 32);
            Console.WriteLine("Bot Key");
            DFS(32, 88);
            Console.WriteLine("House");
            DFS(88, 47);
            Console.WriteLine("Portal");
            DFS(47, 81);
        }

        public static void DFS(int startNode,int endNode)
        {
            Console.WriteLine(startNode);
            Lists.DfsList.Clear();
            Stack<Edges> s = new Stack<Edges>();
            Edges edge = new Edges(graph.GetNode(startNode), graph.GetNode(startNode));
            s.Push(edge);

            while (s.Count() != 0)
            {
                Edges tmpEdge = s.Pop();

                
                if (!Lists.DfsList.Contains(tmpEdge.Destination1))
                {
                    Lists.DfsList.Add(tmpEdge.Destination1);
                    tmpEdge.Destination1.ParrentID1 = tmpEdge.StartDestination1.ID1;
                    Console.WriteLine(tmpEdge.Destination1.ID1);
                }
                if (tmpEdge.Destination1.ID1 == endNode)
                {
                    break;
                }
                foreach (Edges i in tmpEdge.Destination1.EdgeList)
                {
                    foreach (var e in Lists.BlockedList)
                    {
                        if (!Lists.DfsList.Contains(i.Destination1) && i.Destination1.Rect != e.Rect)
                        {
                            s.Push(i);
                        }
                    }
                }
            }
            foreach (var item in Lists.DfsList)
            {
                Grid.Check.Rect = item.Rect;
                Thread.Sleep(500);
            }
        }


        public void SetData()
        {
            for (int i = 0; i < 100; i++)
            {
                
                try
                {
                    if (!Lists.BlockedList.Contains(Grid.GridPoints.ElementAt(i - 1)))
                    {

                        graph.GetNode(i).EdgeList.Add(new Edges(graph.GetNode(i - 1), graph.GetNode(i)));
                    }
                }
                catch (Exception)
                {}

                try
                {
                    if (!Lists.BlockedList.Contains(Grid.GridPoints.ElementAt(i - 10)))
                    {
                        graph.GetNode(i).EdgeList.Add(new Edges(graph.GetNode(i - 10), graph.GetNode(i)));
                    }
                }
                catch (Exception)
                {}

                try
                {
                    if (!Lists.BlockedList.Contains(Grid.GridPoints.ElementAt(i + 1)))
                    {
                        graph.GetNode(i).EdgeList.Add(new Edges(graph.GetNode(i + 1), graph.GetNode(i)));
                    }
                }
                catch (Exception)
                {}

                try
                {
                    if (!Lists.BlockedList.Contains(Grid.GridPoints.ElementAt(i + 10)))
                    {
                        graph.GetNode(i).EdgeList.Add(new Edges(graph.GetNode(i + 10), graph.GetNode(i)));
                    }
                }
                catch (Exception)
                {}
            }
        }
    }
}
