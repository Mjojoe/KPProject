using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Monsters.Parents;

namespace GameLogic.Monsters
{
    internal class Dragon : FireMonster
    {
        string Name { get; }
        int Power { get; }
        public Dragon(string name, int power)
        {
            Name = name;
            Power = power;
        }
        public override Clan IsClan()
        {
            return Clan.Dragon;
        }

        public override bool IsImmune(IMonster enemy)
        {
            if (enemy.IsClan() == Clan.Goblin) return true;
            else return false;
        }
    }
}
