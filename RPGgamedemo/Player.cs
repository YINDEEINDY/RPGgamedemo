using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace RPGgamedemo
{
    class Player : Charactor
    {
        private int NUmportions = 3;
       
        public Player(string name, int health, ConsoleColor color)
            :base(name, health, color,ArtAssets.Player)
        {

        }

        private void ThrowDirtAt(Charactor otherCharactor)
        {
            Write($"You throw a clum of dirt");
            int randomPercent = RandGenerator.Next (1, 101);
            if (randomPercent <= 90)
            {
                WriteLine("and it hits!");
                otherCharactor.TakeDamage(2);
            }
            else
            {
                WriteLine("and it misses...");
            }
        }

        private void SwingAt(Charactor otherCharactor)
        {
            Write($"You take a mighty swing");
            int randomPercent = RandGenerator.Next(1, 101);
            if (randomPercent <= 50)
            {
                WriteLine("and it connects solidly! ");
                otherCharactor.TakeDamage(4);
            }

        }

        private void Potion(Charactor otherCharactor)
        {
            Write($"You Drink the potions");
            int randomPercent = RandGenerator.Next(1, 101);
            if (randomPercent <= 30)
            {
                WriteLine(); 
            }

        }
        public override void Fight(Charactor otherCharactor)
        {
            //WriteLine($"Player{Name} attacks { otherCharactor.Name}");
            ForegroundColor = Color;
            WriteLine($@"You are facing {otherCharactor.Name}.What would you like to do?
 1.) Pick up a clump of dirt and throw it (90% chance to do 2 damage).
 2.)Take a mighty swing with a twig (50% chance to do 4 damage).
 3.)Drink a potion.");
            ConsoleKeyInfo keyInfo = ReadKey(true);
            if (keyInfo.Key == ConsoleKey.D1)   ////key 1 skill
            {
                ThrowDirtAt(otherCharactor);
            }
            else if (keyInfo.Key == ConsoleKey.D2)    ///key2 skill
            {
                SwingAt(otherCharactor);  ///สกิลตัวละครโบ๊ะๆ
            }
            else if (keyInfo.Key == ConsoleKey.D3)
            {

            }
            else
            {
                WriteLine("That's not a valid moveie. Try again. ");
                Fight(otherCharactor);
                return;
            }
            ResetColor();
           
        }

    }
}
