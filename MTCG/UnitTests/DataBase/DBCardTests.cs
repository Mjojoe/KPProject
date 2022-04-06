using NUnit.Framework;
using DataBase;
using DataBase.CardCommands;
using UnitTests.Support;

namespace UnitTests.DataBase
{
    [TestFixture]
    internal class DBCardTests
    {
        static DBSupport sup = DBSupport.GetDBSupport();

        [Test]
        public void GetType_Spell()
        {
            Cards card = Cards.GetDBCards();
            string awnser = card.GetType("FireSpell");

            Assert.AreEqual("spell", awnser);
        }

        [Test]
        public void GetType_Monster()
        {
            Cards card = Cards.GetDBCards();
            string awnser = card.GetType("FireDragon");

            Assert.AreEqual("monster", awnser);
        }

        [Test]
        public void GetElement_Fire()
        {
            Cards card = Cards.GetDBCards();
            string awnser = card.GetElement("FireSpell");

            Assert.AreEqual("fire", awnser);
        }

        [Test]
        public void GetElement_Water()
        {
            Cards card = Cards.GetDBCards();
            string awnser = card.GetElement("WaterSpell");

            Assert.AreEqual("water", awnser);
        }

        [Test]
        public void GetElement_Normal()
        {
            Cards card = Cards.GetDBCards();
            string awnser = card.GetElement("Spell");

            Assert.AreEqual("normal", awnser);
        }

        [TestCase("Knight")]
        [TestCase("Dragon")]
        [TestCase("Elf")]
        [TestCase("Kraken")]
        [TestCase("Ork")]
        [TestCase("Wizard")]
        [TestCase("goblin")]
        public void GetClan_Monsters(string name)
        {
            Cards card = Cards.GetDBCards();
            string awnser = card.GetClan(name);
            
            Assert.AreEqual(name.ToLower(), awnser);
        }

        [Test]
        public void GetClan_Spell()
        {
            Cards card = Cards.GetDBCards();
            string awnser = card.GetClan("Spell");

            Assert.AreEqual("spell", awnser);
        }

        [Test]
        public void AddCard_Success()
        {
            sup.ResetCards();
            string cardID = "testID";
            string name = "testcard";
            float power = 9.0f;
            Cards card = Cards.GetDBCards();
            string awnser = card.AddCard(cardID, name, power);

            Assert.AreEqual(cardID + " Saved in DB\n", awnser);
            sup.ResetCards();
        }

        [Test]
        public void AddCard_Failure()
        {
            sup.ResetCards();
            string cardID = "testID";
            string name = "testcard";
            float power = 9.0f;
            Cards card = Cards.GetDBCards();
            card.AddCard(cardID, name, power);
            string awnser = card.AddCard(cardID, name, power);

            Assert.AreEqual("Card Already Exists!\n", awnser);
            sup.ResetCards();
        }
    }
}
