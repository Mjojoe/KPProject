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
            _kraken = new Kraken("testKraken",1);
            _fireSpell = new FireSpell("testSpell", 1);
        }

        [Test]
        public void Test1()
        {
            Assert.True(_kraken.IsImmune(_fireSpell);
        }
    }
}