using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Monsters.Parents;

namespace GameLogic.Monsters
{
    public class Dragon : NormalMonster
    {
        public override string Name { get; }
        public override int Power { get; }
        public override Clan Clan { get { return Clan.Dragon; } }
        public Dragon(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public override bool IsImmune(Card enemy)
        {
            if (enemy.Clan == Clan.Goblin) return true;
            else return false;
        }
    }
}
