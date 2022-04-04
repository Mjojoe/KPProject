using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Card : ICard
    {
        public virtual string Name { get; }

        public virtual int Power { get; }

        public virtual Type Type { get; }

        public virtual Element Element { get; }

        public virtual Clan Clan { get; }

        public virtual bool HasAdvantage(Card enemy)
        {
            return false;        
        }

        public virtual bool IsImmune(Card enemy)
        {
            return false;
        }
    }
}
