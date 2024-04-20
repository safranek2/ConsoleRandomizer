using ConsoleRandomizer;

namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Třída obsahující testy pro třídu CardGenerator.
    /// </summary>
    [TestClass]
    public class CardGeneratorTests
    {
        CardGenerator cardGenerator; // Instance třídy CardGenerator pro testování

        [TestInitialize]
        public void SetUp()
        {
            cardGenerator = new CardGenerator(); // Inicializace instance třídy CardGenerator před každým testem
        }

        /// <summary>
        /// Testuje vytvoření standardního balíčku s 52 kartami.
        /// </summary>
        [TestMethod]
        public void TestCreateDeck_Standard52Cards()
        {
            int choice = 1;

            List<string> deck = cardGenerator.CreateDeck(choice); // Vytvoření balíčku podle zvolené volby

            Assert.AreEqual(52, deck.Count); // Ověření, že balíček obsahuje 52 karet
        }

        /// <summary>
        /// Testuje vytvoření balíčku s 54 kartami včetně 2 žolíků.
        /// </summary>
        [TestMethod]
        public void TestCreateDeck_54CardsWith2Jokers()
        {
            int choice = 2;

            List<string> deck = cardGenerator.CreateDeck(choice); // Vytvoření balíčku podle zvolené volby

            Assert.AreEqual(54, deck.Count); // Ověření, že balíček obsahuje 54 karet
        }

        /// <summary>
        /// Testuje vytvoření balíčku s 56 kartami včetně 4 žolíků.
        /// </summary>
        [TestMethod]
        public void TestCreateDeck_56CardsWith4Jokers()
        {
            int choice = 3;

            List<string> deck = cardGenerator.CreateDeck(choice); // Vytvoření balíčku podle zvolené volby

            Assert.AreEqual(56, deck.Count); // Ověření, že balíček obsahuje 56 karet
        }

        /// <summary>
        /// Testuje vytvoření balíčku s 36 kartami (6-A).
        /// </summary>
        [TestMethod]
        public void TestCreateDeck_36Cards()
        {
            int choice = 4;

            List<string> deck = cardGenerator.CreateDeck(choice); // Vytvoření balíčku podle zvolené volby

            Assert.AreEqual(36, deck.Count); // Ověření, že balíček obsahuje 36 karet
        }

        /// <summary>
        /// Testuje vytvoření balíčku s 32 kartami (7-A).
        /// </summary>
        [TestMethod]
        public void TestCreateDeck_32Cards()
        {
            int choice = 5;

            List<string> deck = cardGenerator.CreateDeck(choice); // Vytvoření balíčku podle zvolené volby

            Assert.AreEqual(32, deck.Count); // Ověření, že balíček obsahuje 32 karet
        }

        /// <summary>
        /// Testuje vytvoření balíčku s 24 kartami (9-A).
        /// </summary>
        [TestMethod]
        public void TestCreateDeck_24Cards()
        {
            int choice = 6;

            List<string> deck = cardGenerator.CreateDeck(choice); // Vytvoření balíčku podle zvolené volby

            Assert.AreEqual(24, deck.Count); // Ověření, že balíček obsahuje 24 karet
        }

        /// <summary>
        /// Testuje vytahování karty z neprázdného balíčku.
        /// </summary>
        [TestMethod]
        public void TestDrawCard_NotEmptyDeck()
        {
            List<string> deck = new List<string>() { "Ace of Spades", "King of Hearts", "Queen of Diamonds" };

            string drawnCard = cardGenerator.DrawCard(deck); // Vytažení karty z neprázdného balíčku

            Assert.IsTrue(deck.Contains(drawnCard)); // Ověření, že vytažená karta je skutečně v balíčku
        }

        /// <summary>
        /// Testuje vytahování karty z prázdného balíčku.
        /// </summary>
        [TestMethod]
        public void TestDrawCard_EmptyDeck()
        {
            List<string> deck = new List<string>(); // Prázdný balíček

            // Ověření, že vytažení karty z prázdného balíčku vyvolá výjimku ArgumentOutOfRangeException
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => cardGenerator.DrawCard(deck));
        }
    }
}
