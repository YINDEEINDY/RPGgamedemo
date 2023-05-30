using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RPGgamedemo
{
    class Cerfur : Charactor
    {
        private bool HasPoisonPunch;
        

        public Cerfur(String name, int health, ConsoleColor color, bool hasPoisonString)
            :base(name, health, color, ArtAssets.Cerfur)
        {
            HasPoisonPunch = hasPoisonString; 
        }
        public void Energy()
        {
            BackgroundColor = Color;
            Write($" {Name} ");
            ResetColor();
            WriteLine(" I will kill you with my hands!!! ");

        }
        public void Hit()
        {
            BackgroundColor = Color;
            Write($" {Name} ");
            ResetColor();
            WriteLine(" I will kill you fool ");
            if (HasPoisonPunch)
            {
                WriteLine("poison punch!");
            }
            else
            { 
                 WriteLine("normal punch!");
            }

        }
        public override void Fight(Charactor otherCharactor)
        {
            
            ForegroundColor = Color;
            WriteLine($"Cerfur{Name}is fighting!");
            ResetColor();
            //int randnum = RandGenerator.Next(1, 101);
            //if (randnum <= 50)
            //{
            //    Energy();
            //}
            //else
            //{
            //    Hit();
            //}

        }

    }
}
