using ADVBuilder.Common;
using Gema2022.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVBuilder.Model
{
    public class CharacterSkills
    {
        [cAttributes(Name = "Age")] public int Age { get; set; } = cCommon.GetRandom(18, 120);
        [cAttributes(Name = "Force")] public int Force { get; set; } = cCommon.GetRandom(0, 100);
        [cAttributes(Name = "Wisdom")] public int Wisdom { get; set; } = cCommon.GetRandom(0, 100);
        [cAttributes(Name = "Physique")] public int Physique { get; set; } = cCommon.GetRandom(0, 100);
        [cAttributes(Name = "Dexterity")] public int Dexterity { get; set; } = cCommon.GetRandom(0, 100);
        [cAttributes(Name = "Smartness")] public int Smartness { get; set; } = cCommon.GetRandom(0, 100);
        [cAttributes(Name = "Experience")] public int Experience { get; set; } = cCommon.GetRandom(0, 100);
        [cAttributes(Name = "Life")] public int Life { get; set; } = cCommon.GetRandom(20, 100);
        [cAttributes(Name = "Mana")] public int Mana { get; set; } = cCommon.GetRandom(20, 100);
        [cAttributes(Name = "Level")] public int Level { get; set; } = cCommon.GetRandom(0, 100);
        public int Xp { get; set; } = 0;
        public int XpNextLevel { get; set; }
    }
}
