using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.Tiled;
using Random = System.Random;

namespace Runner.Core
{
    public class Node
    {
        public List<int> ConnectedNodes => new List<int>();
        public TiledObject Attributes;

        public Node(TiledObject node)
        {
            Attributes = node;
        }

        public Node(TiledObject node, List<int> connectedNodes)
        {
            Attributes = node;
            ConnectedNodes.AddRange(connectedNodes);
        }

        public void AddConnectedNode(int node)
        {
            ConnectedNodes.Add(node);
        }

        public void AddConnectedNodes(IEnumerable<int> nodes)
        {
            ConnectedNodes.AddRange(nodes);
        }

        public int GetConnectedNode()
        {
            var nodeIndex = new Random(GetHashCode()).Next(0, ConnectedNodes.Count - 1);
            return ConnectedNodes[nodeIndex];
        }
         


    }
}
