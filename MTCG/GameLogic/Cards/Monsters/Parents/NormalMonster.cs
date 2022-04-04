using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Monsters.Parents
{
    public class NormalMonster : Card
    { 
        public override Type Type { get { return Type.Monster; } }
        public override Element Element { get { return Element.Normal; } }

        public override bool HasAdvantage(Card enemy)
        {
            if (enemy.Element == Element.Water) return true;
            else return false;
        }
    }
}
