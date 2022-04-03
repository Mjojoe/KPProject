﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Monsters.Parents
{
    public class WaterMonster : IMonster
    {
        public virtual Clan Clan { get; }
        public virtual string Name { get; }
        public virtual int Power { get; }
        public Type Type { get { return Type.Monster; } }
        public Element Element { get { return Element.Water; } }

        public virtual bool HasAdvantage(ICard enemy)
        {
            if (enemy.Element == Element.Fire) return true;
            else return false;
        }

        public virtual bool IsImmune(IMonster enemy)
        {
            return false;
        }
    }
}
