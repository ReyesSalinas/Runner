using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Core.Common.AI.Pathfinding
{
    public static class NodeManager
    {
        public static Dictionary<string, List<Node>> NodeCollections;

        //static NodeManager() {
        //    NodeCollections = new Dictionary<string, List<Node>>();
        //    Initialize();    
        //}
        public static void Initialize()
        {
            
            var nodeFiles = Directory.GetFiles(@"../../data/nodes");
            var directory = new DirectoryInfo(@"../../data/nodes");
            var files  = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                
                var jArray = JArray.Parse(File.ReadAllText(@file.FullName));
                var nodes = new List<Node>();
                foreach(var item in jArray)
                {
                    var node = JsonConvert.DeserializeObject<Node>(item.ToString());
                    nodes.Add(node);
                }
                var name = Path.GetFileNameWithoutExtension(file.FullName);
                NodeCollections.Add(name,nodes);                               
            }
        }
    }
}
