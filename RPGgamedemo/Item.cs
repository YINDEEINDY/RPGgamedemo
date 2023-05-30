using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgamedemo
{
    class Item
    {
        public string Name { get; private  set; }
        public int Quanitity { get; private set; }

        public Item(string name, int quanitity)
        {
            Name = name;
            Quanitity = quanitity;
        }
    }
}
