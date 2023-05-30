using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Figgle;
namespace RPGgamedemo
{
    class Game
    {
        private Weapon equipedWeapon;
        private Level CurrentLevel;
        private Player CurrentPlayer;
        private Charactor CurrentEnemy;
        private List <Charactor> Enemies;
        /// <summary>
        /// 
        /// </summary>
        public Game()
        {
            Seizark fireAuntie = new Seizark("Fire Auntie",5,ConsoleColor.Red, 3);
            //fireAuntie.TakeDamage(4);

            Seizark hades = new Seizark("Hades", 10,ConsoleColor.Magenta, 6);
            Item leafNinjaStar = new Item("Leaf Ninja Star", 10);           
            hades.PickUpItem(leafNinjaStar);
            //hades.TakeDamage(9);

            Cerfur buzzCerfur = new Cerfur("BuzzCurfur", 15, ConsoleColor.DarkYellow, false);
            //hades.TakeDamage(14);


            Enemies = new List<Charactor>() { fireAuntie, hades, buzzCerfur};

            CurrentLevel = new Level(1, 100);

            equipedWeapon = new Weapon("sword", 10);


        }




        public void EquipedWeapon(Weapon weapon)
        {
            equipedWeapon = weapon;
            WriteLine("Weapon equipedWeapon " + equipedWeapon.Name);
        }

        public void EquipWeapon(Weapon weapon)
        {
            equipedWeapon = weapon;
            WriteLine("Weapon equipped: "+equipedWeapon.Name);
        }



        public void LevelUp() //Level1-100
        {
            CurrentLevel.LevelNumber++;
            CurrentLevel.ExperienceRequired += 100;

            WriteLine("Level Up ! You are now at Level " + CurrentLevel.LevelNumber);
        }




        public void Run()
        {
            RunIntro();

            for (int i = 0; i < Enemies.Count; i += 1)
            {
                CurrentEnemy = Enemies[i];
                IntroCurrentEnemy();
                BattleCurrentEnemy();

                if (CurrentPlayer.IsDead)
                {
                    WriteLine("you were defeated...");
                    WaitForKey();
                    break;
                }
                else
                {
                    WriteLine($"You defasted {CurrentEnemy.Name}!!");
                    WaitForKey();
                }

            }
            if (CurrentPlayer.IsDead)
            {
                WriteLine("you lose");
            }
            else
            {
                WriteLine("You win");
            }
            CurrentPlayer.TakeDamage(1000); 
            RunGameOver();
            WaitForKey();
        }

        private void RunIntro()
        {
            WriteLine(FiggleFonts.Ogre.Render("Micro RPG v.1.1.1.1"));

            Write("What is your name?: ");
            string name = ReadLine();

            CurrentPlayer = new Player(name, 20, ConsoleColor.Green);

            ForegroundColor =ConsoleColor.Green;
            WriteLine(@"You wake up outside and look around at a field of blades of grass towering over you...
     /  /          \
/   /   \          /   \
\   \   /          \   /  /
/   /  /     o   \  \  \  \
\  /  /  /  /|\  /  /  /  /
 \ \  \ /   / \  \ /   \ / 
");
            ResetColor();
            WaitForKey();

            Clear();
            WriteLine($@"    
Your memory is hazy, but you remember flashes of a science exptyjeriment.
accidentally shrunk yourself down to the size of a quarter. 
You look around and see a colony of ants has taken an interest in you. 
Looks like you are going to have to fight your way to the safety.

Are you ready? Yo've got {Enemies.Count} x insects approaching...
");
            CurrentPlayer.DisplayInfo();
            WaitForKey();
        }


        private void RunGameOver()
        {
            Clear();
            if (CurrentPlayer.IsDead)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine($@"
  ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  
 ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒
▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒
░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  
░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒
 ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░
  ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░
░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ 
      ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     
                                                     ░                   
");
                ResetColor();
            }
            else
            {
                WriteLine(@"         
          _______                     _________ _       
|\     /|(  ___  )|\     /|  |\     /|\__   __/( (    /|
( \   / )| (   ) || )   ( |  | )   ( |   ) (   |  \  ( |
 \ (_) / | |   | || |   | |  | | _ | |   | |   |   \ | |
  \   /  | |   | || |   | |  | |( )| |   | |   | (\ \) |
   ) (   | |   | || |   | |  | || || |   | |   | | \   |
   | |   | (___) || (___) |  | () () |___) (___| )  \  |
   \_/   (_______)(_______)  (_______)\_______/|/    )_)
                                                        
~ Have a good day Thamk you!");
            }

            WriteLine(@"~ Thanks for playing
");

        }
        private void IntroCurrentEnemy()
        {
            ForegroundColor = CurrentEnemy.Color;
            WriteLine("A new enemy approaches");
            ResetColor();
            CurrentEnemy.DisplayInfo();
            WriteLine();
            WaitForKey();
        }

        private void BattleCurrentEnemy()
        {
            while (CurrentPlayer.IsAlive || CurrentEnemy.IsAlive)
            {
                Clear();
                CurrentPlayer.DisplayHealthBar();
                CurrentEnemy.DisplayHealthBar();
                
                WriteLine();
                CurrentPlayer.Fight(CurrentEnemy);

                if (CurrentPlayer.IsDead || CurrentEnemy.IsDead)
                {
                    break;
                }
                WriteLine();
                WaitForKey();

                Clear();
                CurrentPlayer.DisplayHealthBar();
                CurrentEnemy.DisplayHealthBar();
                WriteLine();

                CurrentPlayer.Fight(CurrentPlayer);
                WaitForKey();
            } 

        }



        private void WaitForKey()
        {
            WriteLine("Press any key continue...\n");

            ReadKey(true);   
        }

    }
          
    
}
