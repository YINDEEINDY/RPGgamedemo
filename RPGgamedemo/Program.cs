using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace RPGgamedemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test
            Console.Title = "Micro RPG";

            Game myGame = new Game();


            myGame.Run();


            string randomSkill = GenerateRandomSkill();
            WriteLine($"Yous random skill is: {randomSkill}");

        }
        static string GenerateRandomSkill()
        {
            string[] skills =
            {
                "Fireball",
                "Healing Touch",
                "Stealth Strike",
                "Electric Shock",
                "Summon Minions"
            };

            Random random = new Random();
            int index = random .Next(0,skills.Length);


            return skills[index];
        }


    }
}
