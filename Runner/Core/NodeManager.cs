using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Newtonsoft.Json;
namespace Runner.Core
{
    public class NodeCollection
    {
        public List<Node> Nodes => new List<Node>();
        public string Name { get; set; }
        public NodeCollection()
        {

        }

        public NodeCollection(string fileName)
        {

        }

        public void JSONToObject(string fileName)
        {
            var json = new StreamReader(fileName).ReadToEnd();
        }
    }
}
