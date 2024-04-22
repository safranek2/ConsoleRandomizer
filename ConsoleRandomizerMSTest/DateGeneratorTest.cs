namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Třída obsahující testy pro třídu DateGenerator.
    /// </summary>
    [TestClass]
    public class DateGeneratorTests
    {
        DateGenerator dateGenerator; // Instance třídy DateGenerator pro testování

        [TestInitialize]
        public void SetUp()
        {
            dateGenerator = new DateGenerator(); // Inicializace instance třídy DateGenerator před každým testem
        }

        /// <summary>
        /// Testuje, zda je náhodně vygenerované datum mezi zadanými prvním a posledním datem.
        /// </summary>
        [TestMethod]
        public void GenerateRandomDate_EqualToFirstOrLastDate()
        {
            DateTime firstDate = new DateTime(2024, 1, 1);
            DateTime lastDate = new DateTime(2024, 12, 31);

            // Generuje náhodné datum mezi zadanými daty
            DateTime generatedDate = dateGenerator.GenerateDate(firstDate, lastDate);

            // Ověření, že náhodně vygenerované datum je mezi prvním a posledním datem
            Assert.IsTrue(generatedDate >= firstDate && generatedDate <= lastDate);
        }

        /// <summary>
        /// Testuje, že pokud jsou zadaná stejná data jako vstup, je vráceno stejné datum.
        /// </summary>
        [TestMethod]
        public void GenerateRandomDate_SameFirstAndLastDate()
        {
            DateTime sameDate = new DateTime(2024, 1, 1);

            // Generuje datum, když jsou zadaná stejná data jako vstup
            DateTime resultDate = dateGenerator.GenerateDate(sameDate, sameDate);

            // Ověření, že vrácené datum je stejné jako vstupní datum
            Assert.AreEqual(sameDate, resultDate);
        }
    }
}
