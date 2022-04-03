using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Monsters.Parents;

namespace GameLogic.Monsters
{
    internal class Elf : NormalMonster
    {
        string Name { get; }
        int Power { get; }
        public Elf(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public override Clan IsClan()
        {
            return Clan.Elf;
        }

        public override bool IsImmune(IMonster enemy)
        {
            if(enemy.IsClan() == Clan.Dragon) return true;
            else return false;
        }
    }
}
