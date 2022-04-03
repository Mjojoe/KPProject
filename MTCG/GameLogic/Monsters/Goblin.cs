using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Monsters.Parents;

namespace GameLogic.Monsters
{
    internal class Goblin : NormalMonster
    {
        string Name { get; }
        int Power { get; }
        public Goblin(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public override Clan IsClan()
        {
            return Clan.Goblin;
        }

        public override bool IsImmune(IMonster enemy)
        {
            return false;
        }
    }
}
