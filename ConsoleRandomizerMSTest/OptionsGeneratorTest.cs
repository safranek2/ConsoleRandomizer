namespace ConsoleRandomizerMSTest
{
    [TestClass]
    public class OptionsGeneratorTest
    {
        OptionsGenerator optionsGenerator; // Deklarace instance třídy OptionsGenerator pro testování.

        [TestInitialize]
        public void SetUp()
        {
            optionsGenerator = new OptionsGenerator(); // Inicializace instance třídy OptionsGenerator před každým testem.
        }

        /// <summary>
        /// Testuje, zda metoda GenerateItem správně vrátí náhodnou možnost z daného seznamu.
        /// </summary>
        [TestMethod]
        public void GenerateItem_ReturnsRandomOptionFromList()
        {
            // Vytvoření seznamu možností
            List<string> options = new List<string> { "Option 1", "Option 2", "Option 3" };

            // Volání metody pro generování náhodné možnosti
            string randomOption = optionsGenerator.GenerateItem(options);

            // Kontrola, zda vygenerovaná možnost je obsažena v seznamu možností
            CollectionAssert.Contains(options, randomOption);
        }
    }
}
