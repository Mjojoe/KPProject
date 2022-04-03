using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public interface IMonster : ICard
    {
        Clan Clan { get; }
        public abstract bool IsImmune(IMonster enemy);

    }
}
