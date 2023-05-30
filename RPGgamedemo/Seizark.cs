using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace RPGgamedemo
{
    class Seizark : Charactor
    {
        private int ChangeDistance;
        private Item CurrentItem;


        public Seizark(String name, int health, ConsoleColor color, int changeDistance)
            :base(name,health,color,ArtAssets.Seizark)
        {
 
            ChangeDistance = changeDistance;
        }

        public void PickUpItem(Item item)
        {
            CurrentItem = item;
        }
        public void Charge()
        {
            BackgroundColor = Color;
            Write($" {Name} ");
            ResetColor();
            //ความคล่องตัวและความเร็วเป็นพิเศษ สามารถเปลี่ยนรูปร่างเพื่อหลบหลีกการโจมตีและรบกวนศัตรูได้
            WriteLine($"{Name} Exceptional agility and speed. {ChangeDistance} Body!");

            if ( CurrentItem != null)
            {
                WriteLine($"They are carryying a{CurrentItem.Name}.");
            }
        }
    
        public void Power()
        {
            BackgroundColor = Color;
            Write($" {Name} ");
            ResetColor();
            WriteLine($"{Name}Can change shape to dodge attacks and annoy enemies!");

        }

        public override void Fight(Charactor otherCharactor)
        {
            //WriteLine($"Seizark{Name}is fighting!{otherCharactor.Name}!");
            //options;
            // -50% Charge กับ Power 4 ดาเมจ
            //-50% miss กับ power

            ForegroundColor = Color;
            int randPercent = RandGenerator.Next(1, 101);
            Write($"Seizark {Name} Charge at {otherCharactor.Name} and ");
            if ( randPercent <= 50 ) 
            {
                WriteLine("hit for 4 damage!");
                otherCharactor.TakeDamage(4);
            }
            else
            {
                WriteLine("misses...");

            }
            ResetColor();
                   
        }
        
    }
}
