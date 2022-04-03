using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Spells.Parent;

namespace GameLogic
{
    internal class NormalSpell : ICard
    {
        public string Name { get; }

        public int Power { get; }

        public bool HasAdvantage(ICard enemy)
        {
            if (enemy.IsElement() == Element.Water) return true;
            else return false;
        }

        public Element IsElement()
        {
            return Element.Normal;
        }
        public Type IsType()
        {
            return Type.Spell;
        }
    }
}
