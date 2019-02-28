using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Core.Common.AI.Pathfinding
{
    public static class NodeManager
    {
        public static Dictionary<string,List<Node>> NodeCollections => new Dictionary<string, List<Node>>();

        public static void Initialize()
        {
            
            var nodeFiles = Directory.GetFiles(@"../../data/nodes");
            var directory = new DirectoryInfo(@"../../data/nodes");
            var files  = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                var json = JObject.Parse(@"../../data/nodes/slime");
                var jArray = (JArray)json["Nodes"];
                var nodeName = json["Name"].ToString();
                var nodes = jArray.ToObject<List<Node>>();
                NodeCollections.Add(nodeName,nodes);
            }
        }
    }
}
