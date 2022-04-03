using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Monsters.Parents
{
    abstract class WaterMonster : IMonster
    {
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
            return Type.Monster;
        }

        public abstract Clan IsClan();

        public abstract bool IsImmune(ICard enemy);
    }
}
