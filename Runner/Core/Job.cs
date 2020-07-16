using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runner.Core
{
    public class Job
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int MagicPoints { get; set; }
        public int Attack { get; set; }
        public int MagicAttack { get; set; }
        public int Defense { get; set; }
        public int MagicDefense { get; set; }
        public float DodgeChance { get; set; }
        public float CriticalChance { get; set; }
        public float StatusResist { get; set; }
        public BaseStats Stats { get; set; }
        private Job Parent { get; set; }
    }
}
