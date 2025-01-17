using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem
{
    internal class Obj : IRessouce
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Prix { get; set; }
        public Obj(string name) { Name = name; }

    }
}
