using NUnit.Framework;
using GameLogic;
using GameLogic.Monsters;
using GameLogic.Spells;

namespace UnitTests
{
    [TestFixture]
    public class GameTests
    {
        [SetUp]
        public void Setup()
        {
            Kraken _kraken = new Kraken("testKraken",1);
            FireSpell _fireSpell = new FireSpell("testSpell", 1);
        }

        [Test]
        public void Test1(Kraken kraken, FireSpell fireSpell)
        {
            Assert.True(kraken.IsImmune(fireSpell));
        }
    }
}