using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RPGgamedemo
{
    public class Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        public Weapon(string name, int damage )
        {
            Name = name;
            Damage = damage;


        }
    }
}
