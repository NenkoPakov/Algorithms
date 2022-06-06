using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._Road_Reconstruction
{
    class Edge
    {
        public string StartNode { get; private set; }
        public string DestinationNode { get; private set; }

        public Edge(string startNode,string destinationNode)
        {
            this.StartNode = startNode;
            this.DestinationNode = destinationNode;
        }

        public override string ToString()
        {
            return this.StartNode + " " + this.DestinationNode;
        }
    }
}
