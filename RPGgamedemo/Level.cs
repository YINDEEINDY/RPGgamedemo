using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGgamedemo
{
    public class Level
    {
        public int LevelNumber { get; set; }
        public int ExperienceRequired { get; set; }

        public Level(int levelNumber, int experienceRequired)
        {
            LevelNumber = levelNumber;
            ExperienceRequired = experienceRequired;
        }
    }
}
