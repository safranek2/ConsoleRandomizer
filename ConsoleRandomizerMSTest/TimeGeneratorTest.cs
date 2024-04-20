namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Testovací třída pro funkčnost třídy TimeGenerator.
    /// </summary>
    [TestClass]
    public class TimeGeneratorTest
    {
        TimeGenerator timeGenerator; // Instance třídy TimeGenerator pro testování.

        /// <summary>
        /// Inicializuje instanci třídy TimeGenerator před spuštěním každého testu.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            timeGenerator = new TimeGenerator(); // Inicializace instance třídy TimeGenerator před každým testem.
        }

        /// <summary>
        /// Testuje, zda metoda GenerateTime vrací náhodný čas mezi zadanými časy.
        /// </summary>
        [TestMethod]
        public void GenerateTime_ReturnsRandomTimeInGivenRange()
        {
            // Příprava vstupních dat
            DateTime firstTime = DateTime.ParseExact("10:00", "H:mm", null);
            DateTime lastTime = DateTime.ParseExact("12:00", "H:mm", null);

            // Provádění testované operace
            DateTime randomTime = timeGenerator.GenerateTime(firstTime, lastTime);

            // Kontrola výstupu
            Assert.IsNotNull(randomTime);
            Assert.IsTrue(randomTime >= firstTime && randomTime <= lastTime);
        }
    }
}
