using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IRessouce> list = new List<IRessouce>();

            list.Add(new Obj("fa"));

            Console.WriteLine(list.ElementAt(0));
        }
    }
}
