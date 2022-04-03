using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Monsters.Parents
{
    abstract class FireMonster : IMonster
    {
        public bool HasAdvantage(ICard enemy)
        {
            if(enemy.IsElement() == Element.Normal) return true;
            else return false;
        }

        public Element IsElement()
        {
            return Element.Fire;
        }

        public Type IsType()
        {
            return Type.Monster;
        }

        public abstract Clan IsClan();

        public abstract bool IsImmune(ICard enemy);

    }
}
