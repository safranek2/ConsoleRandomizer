namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Třída obsahující testy pro třídu CountryGenerator.
    /// </summary>
    [TestClass]
    public class CountryGeneratorTest
    {
        CountryGenerator countryGenerator; // Instance třídy CountryGenerator pro testování

        [TestInitialize]
        public void SetUp()
        {
            countryGenerator = new CountryGenerator(); // Inicializace instance třídy CountryGenerator před každým testem
        }

        /// <summary>
        /// Testuje, zda je možné získat náhodnou zemi ze seznamu zemí.
        /// </summary>
        [TestMethod]
        public void TestGetRandomCountry()
        {
            string randomCountry = countryGenerator.GetRandomCountry(); // Získání náhodné země

            // Ověření, že náhodně vybraná země není null (měla by být validní země)
            Assert.IsNotNull(randomCountry);
        }
    }
}
