using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFindingProject
{
    class Edges
    {
        Nodes StartDestination;
        Nodes Destination;

        public Edges(Nodes destination1, Nodes startDestination1)
        {
            Destination1 = destination1;
            StartDestination1 = startDestination1;
        }

        public Nodes Destination1 { get => Destination; set => Destination = value; }
        public Nodes StartDestination1 { get => StartDestination; set => StartDestination = value; }
    }
}
