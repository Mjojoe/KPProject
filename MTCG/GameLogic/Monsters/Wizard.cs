using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Monsters.Parents;

namespace GameLogic.Monsters.Interfaces
{
    internal class Wizard : WaterMonster
    {
        string Name { get; }
        int Power { get; }
        public Wizard(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public override Clan IsClan()
        {
            return Clan.Wizard;
        }

        public override bool IsImmune(IMonster enemy)
        {
            if (enemy.IsClan() == Clan.Orc) return true;
            else return false;
        }
    }
}
