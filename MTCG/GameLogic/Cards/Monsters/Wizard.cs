using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Monsters.Parents;

namespace GameLogic.Monsters.Interfaces
{
    public class Wizard : WaterMonster
    {
        public override string Name { get; }
        public override int Power { get; }
        public override Clan Clan { get { return Clan.Wizard; } }
        public Wizard(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public override bool IsImmune(IMonster enemy)
        {
            if (enemy.Clan == Clan.Orc) return true;
            else return false;
        }
    }
}
