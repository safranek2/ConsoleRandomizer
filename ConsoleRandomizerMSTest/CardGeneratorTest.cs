namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Třída obsahující testy pro třídu CardGenerator.
    /// </summary>
    [TestClass]
    public class CardGeneratorTests
    {
        /// <summary>
        /// Testuje vytvoření standardního balíčku s 52 kartami.
        /// </summary>
        [TestMethod]
        public void TestCreateDeck_Standard52Cards()
        {
            CardGenerator cardGenerator = new CardGenerator();
            int choice = 1;

            List<string> deck = cardGenerator.CreateDeck(choice);

            Assert.AreEqual(52, deck.Count);
        }

        /// <summary>
        /// Testuje vytvoření balíčku s 54 kartami včetně 2 žolíků.
        /// </summary>
        [TestMethod]
        public void TestCreateDeck_54CardsWith2Jokers()
        {
            CardGenerator cardGenerator = new CardGenerator();
            int choice = 2;

            List<string> deck = cardGenerator.CreateDeck(choice);

            Assert.AreEqual(54, deck.Count);
        }

        /// <summary>
        /// Testuje vytvoření balíčku s 56 kartami včetně 4 žolíků.
        /// </summary>
        [TestMethod]
        public void TestCreateDeck_56CardsWith4Jokers()
        {
            CardGenerator cardGenerator = new CardGenerator();
            int choice = 3;

            List<string> deck = cardGenerator.CreateDeck(choice);

            Assert.AreEqual(56, deck.Count);
        }

        /// <summary>
        /// Testuje vytvoření balíčku s 36 kartami (6-A).
        /// </summary>
        [TestMethod]
        public void TestCreateDeck_36Cards()
        {
            CardGenerator cardGenerator = new CardGenerator();
            int choice = 4;

            List<string> deck = cardGenerator.CreateDeck(choice);

            Assert.AreEqual(36, deck.Count);
        }

        /// <summary>
        /// Testuje vytvoření balíčku s 32 kartami (7-A).
        /// </summary>
        [TestMethod]
        public void TestCreateDeck_32Cards()
        {
            CardGenerator cardGenerator = new CardGenerator();
            int choice = 5;

            List<string> deck = cardGenerator.CreateDeck(choice);

            Assert.AreEqual(32, deck.Count);
        }

        /// <summary>
        /// Testuje vytvoření balíčku s 24 kartami (9-A).
        /// </summary>
        [TestMethod]
        public void TestCreateDeck_24Cards()
        {
            CardGenerator cardGenerator = new CardGenerator();
            int choice = 6;

            List<string> deck = cardGenerator.CreateDeck(choice);

            Assert.AreEqual(24, deck.Count);
        }

        /// <summary>
        /// Testuje vytahování karty z neprázdného balíčku.
        /// </summary>
        [TestMethod]
        public void TestDrawCard_NotEmptyDeck()
        {
            CardGenerator cardGenerator = new CardGenerator();
            List<string> deck = new List<string>() { "Ace of Spades", "King of Hearts", "Queen of Diamonds" };

            string drawnCard = cardGenerator.DrawCard(deck);

            Assert.IsTrue(deck.Contains(drawnCard));
        }

        /// <summary>
        /// Testuje vytahování karty z prázdného balíčku.
        /// </summary>
        [TestMethod]
        public void TestDrawCard_EmptyDeck()
        {
            CardGenerator cardGenerator = new CardGenerator();
            List<string> deck = new List<string>();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => cardGenerator.DrawCard(deck));
        }
    }
}
