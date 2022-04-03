using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Monsters.Parents;

namespace GameLogic.Monsters.Interfaces
{
    internal class Orc : FireMonster
    {
        string Name { get; }
        int Power { get; }
        public Orc(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public override Clan IsClan()
        {
            return Clan.Orc;
        }

        public override bool IsImmune(IMonster enemy)
        {
            return false;
        }
    }
}
