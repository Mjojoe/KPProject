using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Spells.Parent;

namespace GameLogic
{
    internal class FireSpell : ICard
    {
        public string Name { get; }
        public int Power { get; }
        public FireSpell(string name, int power)
        {
            Name = name;
            Power = power;
        }
        
        public Element IsElement()
        {
            return Element.Fire;
        }
        public bool HasAdvantage(ICard enemy)
        {
            if (enemy.IsElement() == Element.Normal) return true;
            else return false;
        }

        public Type IsType()
        {
            return Type.Spell;
        }
    }
}
