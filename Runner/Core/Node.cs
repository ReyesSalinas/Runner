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
        public List<Node> ConnectedNodes => new List<Node>();
        public TiledObject Attributes;

        public Node(TiledObject node)
        {

        }

        public Node(TiledObject node, List<Node> connectedNodes)
        {
            Attributes = node;
            ConnectedNodes.AddRange(connectedNodes);
        }

        public void AddConnectedNode(Node node)
        {
            ConnectedNodes.Add(node);
        }

        public void AddConnectedNodes(IEnumerable<Node> nodes)
        {
            ConnectedNodes.AddRange(nodes);
        }

        public Node GetConnectedNode()
        {
            var nodeIndex = new Random(GetHashCode()).Next(0, ConnectedNodes.Count - 1);
            return ConnectedNodes[nodeIndex];
        }
         


    }
}
