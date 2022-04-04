using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public interface ICard
    {
        string Name { get; }
        int Power { get; }
        Type Type { get; }
        Element Element { get; }
        Clan Clan { get; }
        public abstract bool IsImmune(Card enemy);
        bool HasAdvantage(Card enemy);
    }
}
