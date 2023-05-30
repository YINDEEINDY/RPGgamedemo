﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RPGgamedemo
{
    class Charactor
    {
        public string Name { get;protected set; }
        public int Health { get; protected set; }
        public int MaxHealth { get; protected set; }
        public string TextArt { get; protected set; }
        public ConsoleColor Color { get; protected set; }
        public Random RandGenerator { get; protected set; }
        public bool IsDead { get => Health <= 0; }

        public bool IsAlive { get => Health > 0; }

        public Charactor(String name, int health, ConsoleColor color,string textArt)
        {
            Name = name;
            Health = health;
            MaxHealth = health;
            Color = color;
            TextArt = textArt;
            RandGenerator = new Random(); 

        }
        public void DisplayInfo()
        {
            BackgroundColor = Color;
            Write($"- - - {Name} - - -");
            ResetColor();
            ForegroundColor = Color;
            WriteLine($"\n{TextArt}\n");
            WriteLine($"Health: {Health}\n");
            WriteLine("- - -");
            ResetColor();

           
        }
        public virtual void Fight(Charactor otherCharactor)
        {
            WriteLine("Enemy is fighting!");

        }

        public void TakeDamage(int damageAmost)
        {
            Health -= damageAmost;
            if( Health < 0 )
            {
                Health = 0;
            }
        }

        public void DisplayHealthBar()
        {
            ForegroundColor = Color;    
            WriteLine($"{Name}'s Health:");
            ResetColor();
            Write("[");
            BackgroundColor = ConsoleColor.Green;
            for(int i = 0; i < Health; i++)
            {
                Write(" ");
            }
            BackgroundColor = ConsoleColor.Black;
            for(int i = Health;i<MaxHealth;i++)
            {
                Write(" ");
            }
            ResetColor();
            // เลือด 
            WriteLine($"] ({Health}/{MaxHealth})");

            //WriteLine("[===========              ]");
        }
    }
}
