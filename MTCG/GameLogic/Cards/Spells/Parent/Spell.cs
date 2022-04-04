using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Spells.Parent
{
    public class Spell : Card
    {
        public override Type Type { get { return Type.Spell; } }

        public override Clan Clan { get { return Clan.Spell; } }
    }
}

