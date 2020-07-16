using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.AI.Pathfinding;
namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var nodes = NodeManager.NodeCollections;
            Console.WriteLine(nodes);

            Console.ReadKey();
        }
    }
}
