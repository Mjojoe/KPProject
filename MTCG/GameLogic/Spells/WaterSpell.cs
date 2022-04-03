using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Spells.Parent;

namespace GameLogic
{
    internal class WaterSpell : ICard

        public string Name { get; }

        public int Power { get; }

        public bool HasAdvantage(ICard enemy)
        {
            if (enemy.IsElement() == Element.Fire) return true;
            else return false;
        }

        public Element IsElement()
        {
            return Element.Water;
        }
        public Type IsType()
        {
            return Type.Spell;
        }
    }
}
