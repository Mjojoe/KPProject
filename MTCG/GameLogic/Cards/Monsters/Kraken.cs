using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Monsters.Parents;

namespace GameLogic.Monsters
{
    public class Kraken : WaterMonster
    {
        public override string Name { get; }
        public override int Power { get; }
        public override Clan Clan { get { return Clan.Kraken; } }
        public Kraken(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public bool IsImmune(ICard enemy)
        {
            if (enemy.Type == Type.Spell) return true;
            else return false;
        }
    }
}
