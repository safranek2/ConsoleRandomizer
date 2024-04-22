namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Třída obsahující testy pro třídu ListGenerator.
    /// </summary>
    [TestClass]
    public class ListGeneratorTest
    {
        ListGenerator listGenerator; // Instance třídy ListGenerator pro testování

        [TestInitialize]
        public void SetUp()
        {
            listGenerator = new ListGenerator(); // Inicializace instance třídy ListGenerator před každým testem
        }

        /// <summary>
        /// Testuje, zda metoda AddName přidá zadané jméno do seznamu.
        /// </summary>
        [TestMethod]
        public void AddName_AddsNameToList()
        {
            // Vstupní seznam jmen
            List<string> list = new List<string>();

            // Jméno, které bude přidáno
            string name = "John";

            // Přidání jména do seznamu
            listGenerator.AddName(list, name);

            // Ověření, zda jméno bylo úspěšně přidáno do seznamu
            Assert.IsTrue(list.Contains(name));
        }

        /// <summary>
        /// Testuje, zda metoda ShuffleList vrátí seznam s položkami v náhodném pořadí.
        /// </summary>
        [TestMethod]
        public void ShuffleList_ReturnsShuffledList()
        {
            // Vstupní seznam jmen
            List<string> list = new List<string> { "John", "Alice", "Bob", "Emily", "Michael" };

            // Kopie původního seznamu pro porovnání
            List<string> originalList = new List<string>(list);

            // Zamíchání seznamu
            List<string> shuffledList = listGenerator.ShuffleList(list);

            // Ověření, že nový seznam je různý od původního
            CollectionAssert.AreNotEqual(originalList, shuffledList);

            // Ověření, že nový seznam obsahuje stejné prvky jako původní
            CollectionAssert.AreEquivalent(originalList, shuffledList);
        }

        /// <summary>
        /// Testuje, zda metoda ListAsString vrátí správně formátovaný textový řetězec obsahující všechny položky ze seznamu.
        /// </summary>
        [TestMethod]
        public void ListAsString_ReturnsCorrectString()
        {
            // Vstupní seznam jmen
            List<string> list = new List<string> { "John", "Alice", "Bob", "Emily", "Michael" };

            // Očekávaný výstupní textový řetězec
            string expectedString = "Results: John, Alice, Bob, Emily, Michael";

            // Získání výstupního textového řetězce ze seznamu
            string result = listGenerator.ListAsString(list);

            // Ověření, zda výstupní textový řetězec odpovídá očekávanému formátu
            Assert.AreEqual(expectedString, result);
        }
    }
}
