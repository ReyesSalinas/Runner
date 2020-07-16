using System.Collections.Generic;
using System.Linq;
using Nez;
using Nez.Tiled;

namespace Runner.Core
{
    public class NodeCollection : Component
    {
        public List<Node> Nodes = new List<Node>();

        public NodeCollection(TiledObjectGroup tiledGroup)
        {
            Name = tiledGroup.name;
            TiledObjectGroup = tiledGroup;
        }

        private TiledObjectGroup TiledObjectGroup { get; }
        public string Name { get; set; }

        public override void onAddedToEntity()
        {
            var tiledObjects = TiledObjectGroup
                .objects
                .Select(tiledObject => new Node(tiledObject));
            AddRange(tiledObjects);
        }

        public void Add(Node node)
        {
            node.NodeCollection = this;
            Nodes.Add(node);
        }

        public void AddRange(IEnumerable<Node> nodes)
        {
            foreach (var node in nodes) Add(node);
        }
    }
}