using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVBuilder.Model.Abstract
{
    public abstract class CharProperties
    {
        public int Age { get; set; } = 20;
        public int Force { get; set; } = 0;
        public int Wisdom { get; set; } = 0;
        public int Physique { get; set; } = 0;
        public int Dexterity { get; set; } = 0;
        public int Smartness { get; set; } = 0;
        public int Experience { get; set; } = 0;
        public int Life { get; set; } = 10;
        public int Mana { get; set; } = 0;
        public int Xp { get; set; } = 0;
        public int Level { get; set; }
        public int XpNextLevel { get; set; }
    }
}
