using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem
{
    internal interface IItem
    {
        // Propriété, signature
        string Name { get; }
        string Description { get; }
        int Prix { get; }
    }
}
