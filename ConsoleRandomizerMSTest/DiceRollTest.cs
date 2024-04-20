namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Třída obsahující testy pro třídu DiceRoll.
    /// </summary>
    [TestClass]
    public class DiceRollTest
    {
        DiceRoll diceRoll; // Instance třídy DiceRoll pro testování

        [TestInitialize]
        public void SetUp()
        {
            diceRoll = new DiceRoll(); // Inicializace instance třídy DiceRoll před každým testem
        }

        /// <summary>
        /// Testuje, zda generovaný seznam hodnot kostek obsahuje očekávaný počet hodnot.
        /// </summary>
        [TestMethod]
        public void GenerateDiceList_CorrectCount()
        {
            // Předpokládaný počet kostek a stran
            int count = 3;
            int sides = 6;

            // Generuje seznam hodnot kostek
            List<int> diceList = diceRoll.GenerateDiceList(count, sides);

            // Ověření, že počet vygenerovaných hodnot odpovídá očekávanému počtu kostek
            Assert.AreEqual(count, diceList.Count);
        }

        /// <summary>
        /// Testuje, zda výsledný textový řetězec obsahuje správný součet hodnot kostek.
        /// </summary>
        [TestMethod]
        public void GenerateDiceListAsString_CorrectSum()
        {
            // Vstupní seznam hodnot kostek
            List<int> diceValues = new List<int> { 2, 4, 6 };

            // Očekávaný součet hodnot kostek
            int expectedSum = diceValues.Sum();

            // Generuje textový řetězec z hodnot kostek
            string result = diceRoll.GenerateDiceListAsString(diceValues);

            // Ověření, že výsledný text obsahuje správný součet hodnot kostek
            Assert.IsTrue(result.Contains(expectedSum.ToString()));
        }

        /// <summary>
        /// Testuje, zda je vygenerovaný textový řetězec správně formátován pro jednu kostku.
        /// </summary>
        [TestMethod]
        public void GenerateDiceListAsString_SingleDieFormat()
        {
            // Vstupní seznam hodnot kostek pro jednu kostku
            List<int> diceValues = new List<int> { 3 };

            // Generuje textový řetězec z hodnot kostek pro jednu kostku
            string result = diceRoll.GenerateDiceListAsString(diceValues);

            // Ověření, že výsledný text obsahuje pouze jednu hodnotu kostky bez součtu
            Assert.IsTrue(result.Contains(diceValues[0].ToString()));
            Assert.IsFalse(result.Contains("+"));
            Assert.IsFalse(result.Contains("="));
        }

        /// <summary>
        /// Testuje, zda je vygenerovaný textový řetězec správně formátován pro více kostek.
        /// </summary>
        [TestMethod]
        public void GenerateDiceListAsString_MultipleDiceFormat()
        {
            // Vstupní seznam hodnot kostek pro více kostek
            List<int> diceValues = new List<int> { 2, 4, 6 };

            // Generuje textový řetězec z hodnot kostek pro více kostek
            string result = diceRoll.GenerateDiceListAsString(diceValues);

            // Ověření, že výsledný text obsahuje správně oddělené hodnoty kostek s '+' a správně spočítaný součet
            Assert.AreEqual(result, "Rolled dice: 2 + 4 + 6 = 12");
        }
    }
}
