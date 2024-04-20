namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Třída obsahující testovací metody pro načítání odpovědí do Magické koule z JSON souboru.
    /// </summary>
    [TestClass]
    public class LoadMagic8BallAnswersFromJSONTest
    {
        private LoadMagic8BallAnswersFromJSON jsonLoader; // Instance třídy pro načítání dat z JSON
        private string magic8BallAnswersTestFilePath; // Cesta k testovacím souborům s odpověďmi do Magické koule

        /// <summary>
        /// Metoda, která se spustí před spuštěním každé testovací metody.
        /// Inicializuje instanci třídy pro načítání dat a určuje cestu k testovacím souborům.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            magic8BallAnswersTestFilePath = Path.Combine("TestResources", "Magic8BallAnswers");
            jsonLoader = new LoadMagic8BallAnswersFromJSON(magic8BallAnswersTestFilePath);
        }

        /// <summary>
        /// Testuje úspěšné načtení odpovědí do Magické koule z platného JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadMagic8BallAnswersFromJSON_Success()
        {
            string magic8BallAnswersTestFilePathValidFormat = Path.Combine(magic8BallAnswersTestFilePath, "Magic8BallAnswersValidFormat.json");

            // Načtení odpovědí do Magické koule z platného JSON souboru
            List<string> result = jsonLoader.LoadData(magic8BallAnswersTestFilePathValidFormat, false);

            // Ověření, že byly načteny neprázdné data (soubor byl v pořádku)
            Assert.IsNotNull(result, "The method should return not null data if the file was ok.");
        }

        /// <summary>
        /// Testuje chování, kdy není nalezen soubor s odpověďmi do Magické koule.
        /// </summary>
        [TestMethod]
        public void LoadMagic8BallAnswersFromJSON_FileNotFound()
        {
            string magic8BallAnswersTestFilePathNotFound = Path.Combine(magic8BallAnswersTestFilePath, "Magic8BallAnswersNonExistentFile.json");

            // Načtení odpovědí do Magické koule z neexistujícího souboru
            List<string> result = jsonLoader.LoadData(magic8BallAnswersTestFilePathNotFound, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl nalezen)
            Assert.IsNull(result, "The method should not return any data if the file was not found.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadMagic8BallAnswersFromJSON_InvalidJsonFormat1()
        {
            string magic8BallAnswersTestFilePathInvalidFormat1 = Path.Combine(magic8BallAnswersTestFilePath, "Magic8BallAnswersInvalidFormat1.json");

            // Načtení odpovědí do Magické koule z neplatného JSON souboru
            List<string> result = jsonLoader.LoadData(magic8BallAnswersTestFilePathInvalidFormat1, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadMagic8BallAnswersFromJSON_InvalidJsonFormat2()
        {
            string magic8BallAnswersTestFilePathInvalidFormat2 = Path.Combine(magic8BallAnswersTestFilePath, "Magic8BallAnswersInvalidFormat2.json");

            // Načtení odpovědí do Magické koule z neplatného JSON souboru
            List<string> result = jsonLoader.LoadData(magic8BallAnswersTestFilePathInvalidFormat2, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadMagic8BallAnswersFromJSON_InvalidJsonFormat3()
        {
            string magic8BallAnswersTestFilePathInvalidFormat3 = Path.Combine(magic8BallAnswersTestFilePath, "Magic8BallAnswersInvalidFormat3.json");

            // Načtení odpovědí do Magické koule z neplatného JSON souboru
            List<string> result = jsonLoader.LoadData(magic8BallAnswersTestFilePathInvalidFormat3, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadMagic8BallAnswersFromJSON_InvalidJsonFormat4()
        {
            string magic8BallAnswersTestFilePathInvalidFormat4 = Path.Combine(magic8BallAnswersTestFilePath, "Magic8BallAnswersInvalidFormat4.json");

            // Načtení odpovědí do Magické koule z neplatného JSON souboru
            List<string> result = jsonLoader.LoadData(magic8BallAnswersTestFilePathInvalidFormat4, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadMagic8BallAnswersFromJSON.
        /// </summary>
        [TestMethod]
        public void LoadMagic8BallAnswersFromJSON_Constructor1()
        {
            string validPath = Path.Combine(magic8BallAnswersTestFilePath, "Magic8BallAnswersValidFormat.json");

            // Inicializace instance třídy LoadMagic8BallAnswersFromJSON
            LoadMagic8BallAnswersFromJSON validLoader = new LoadMagic8BallAnswersFromJSON(validPath);

            // Ověření, že instance byla inicializována
            Assert.IsNotNull(validLoader, "The constructor should initialize the instance.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadMagic8BallAnswersFromJSON s neplatnou cestou.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadMagic8BallAnswersFromJSON_Constructor2()
        {
            // Inicializace instance třídy LoadMagic8BallAnswersFromJSON s neplatnou cestou (očekává se vyvolání výjimky ArgumentNullException)
            LoadMagic8BallAnswersFromJSON invalidLoader = new LoadMagic8BallAnswersFromJSON(null);
        }
    }
}
