using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;

namespace Runner.Core
{
    public class Node
    {
        public TiledObject Attributes;

        public Node(TiledObject tile)
        {
            Id = tile.id;
            Position = tile.position;
            Name = tile.name;
            ConnectedNodes = tile.properties["ConnectedNodes"]
                .Split(',')
                .Select(int.Parse)
                .ToList();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Vector2 Position { get; set; }
        public NodeCollection NodeCollection { get; set; }
        public List<int> ConnectedNodes { get; set; }

        public int Weight { get; set; }

        public Point TiledPosition => (Position / 32).ToPoint();

        public Node GetNextNode()
        {
            var nextNodeName = ConnectedNodes.randomItem();
            return NodeCollection.Nodes.FirstOrDefault(x => x.Id == nextNodeName);
        }
    }
}