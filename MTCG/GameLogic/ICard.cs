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
        bool HasAdvantage(ICard enemy);
    }
}
