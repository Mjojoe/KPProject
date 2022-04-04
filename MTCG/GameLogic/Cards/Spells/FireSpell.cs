using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Spells.Parent;

namespace GameLogic
{
    public class FireSpell : Spell
    {
        public override string Name { get; }

        public override int Power { get; }

        public override Element Element { get { return Element.Fire; } }
        public FireSpell(string name, int power) { Name = name; Power = power; }

        public override bool HasAdvantage(Card enemy)
        {
            if (enemy.Element == Element.Normal) return true;
            else return false;
        }
    }
}
