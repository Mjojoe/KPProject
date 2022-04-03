﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Spells.Parent;

namespace GameLogic
{
    public class WaterSpell : ICard
    {
        public string Name { get; }

        public int Power { get; }

        public Type Type { get { return Type.Spell; } }

        public Element Element { get { return Element.Water; } }
        public WaterSpell(string name, int power) { Name = name; Power = power; }


        public bool HasAdvantage(ICard enemy)
        {
            if (enemy.Element == Element.Fire) return true;
            else return false;
        }
    }
}