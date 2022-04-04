using System;
using System.Collections.Generic;

namespace GameLogic
{
    internal class Game
    {
        readonly List<Card> Blue;
        readonly List<Card> Red;
        readonly int AdvantageMultiplier = 2;

        public Game(List<Card> blue, List<Card> red) { Blue = blue; Red = red; }

        public void ApplyMultiplier(int attacker, int defender)
        {
            CalculateWinner(attacker * AdvantageMultiplier, defender / AdvantageMultiplier);
        }

        public bool CalculateWinner(int attacker, int defender)
        {
            if (attacker > defender)
                return true;
            else
                return false;
        }

        public void MonsterBattleRound(Card blue, Card red)
        {
            if(!red.IsImmune(blue))
                CalculateWinner(blue.Power, red.Power);
            if (!blue.IsImmune(red))
                CalculateWinner(red.Power, blue.Power);
        }

        public void SpellBattleRound(Card blue, Card red) 
        {
            if (!red.IsImmune(blue))
                if (blue.HasAdvantage(red))
                ApplyMultiplier(blue.Power, red.Power);
                else
                CalculateWinner(blue.Power, red.Power);

            if (!blue.IsImmune(red))
                if (red.HasAdvantage(blue))
                    ApplyMultiplier(red.Power, blue.Power);
                else
                    CalculateWinner(red.Power,blue.Power);
        }

        public void Battle(Card blue, Card red)
        {
            if (blue.Type == Type.Spell || red.Type == Type.Spell)
                SpellBattleRound(blue, red);
            else 
                MonsterBattleRound(blue, red);
        }

        public void RunGame()
        {
            int count = 0;
            foreach (Card c in Blue)
            {
                Battle(c,Red[count++]);
            }
        }
        
        public static void Main() 
        {

        }


    }
}
