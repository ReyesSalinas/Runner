using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.Tiled;
using Random = System.Random;
namespace Core.Common.AI.Pathfinding
{
    public class Node
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> ConnectedNodes => new List<int>();
        public int Weight { get; set; }
        public TiledObject Attributes;

        public Node(TiledObject tile)
        {
            Attributes = tile;
        }

        public Node(TiledObject tile, List<int> connectedNodes)
        {
            Attributes = tile;
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
