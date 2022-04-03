using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Monsters.Parents;

namespace GameLogic.Monsters
{
    internal class Kraken : WaterMonster
    {
        string Name { get; }
        int Power { get; }
        public Kraken(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public override Clan IsClan()
        {
            return Clan.Kraken;
        }

        public override bool IsImmune(IMonster enemy)
        {
            if (enemy.IsType() == Type.Spell) return true;
            return false;
        }
    }
}
