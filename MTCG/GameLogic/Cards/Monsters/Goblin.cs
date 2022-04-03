using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Monsters.Parents;

namespace GameLogic.Monsters
{
    public class Goblin : NormalMonster
    {
        public override string Name { get; }
        public override int Power { get; }
        public override Clan Clan { get { return Clan.Goblin; } }
        public Goblin (string name, int power)
        {
            Name = name;
            Power = power;
        }
    }
}
