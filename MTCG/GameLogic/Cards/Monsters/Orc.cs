using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Monsters.Parents;

namespace GameLogic.Monsters.Interfaces
{
    public class Orc : FireMonster
    {
        public override string Name { get; }
        public override int Power { get; }
        public override Clan Clan { get { return Clan.Orc; } }
        public Orc(string name, int power)
        {
            Name = name;
            Power = power;
        }
    }
}
