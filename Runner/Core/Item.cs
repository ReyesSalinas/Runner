using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runner.Core
{
    public class Item
    { 
        public int Id { get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
    }
}
