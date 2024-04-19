namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Třída obsahující testy pro třídu CountryGenerator.
    /// </summary>
    [TestClass]
    public class CountryGeneratorTest
    {
        /// <summary>
        /// Testuje, zda je možné získat náhodnou zemi ze seznamu zemí.
        /// </summary>
        [TestMethod]
        public void TestGetRandomCountry()
        {
            CountryGenerator countryGenerator = new CountryGenerator();

            string randomCountry = countryGenerator.GetRandomCountry();

            Assert.IsNotNull(randomCountry);
        }
    }
}
