using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Spells.Parent;

namespace GameLogic
{
    public class NormalSpell : Spell
    {
        public override string Name { get; }

        public override int Power { get; }

        public override Element Element { get { return Element.Normal; } }
        public NormalSpell(string name, int power) { Name = name; Power = power; }

        public override bool HasAdvantage(Card enemy)
        {
            if (enemy.Element == Element.Water) return true;
            else return false;
        }
    }
}
