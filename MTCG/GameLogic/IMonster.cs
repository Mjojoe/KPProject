using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    interface IMonster : ICard
    {
        public abstract Clan IsClan();
        public abstract bool IsImmune(ICard enemy);

    }
}
