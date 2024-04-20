namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Třída obsahující testovací metody pro načítání abeced z JSON souboru.
    /// </summary>
    [TestClass]
    public class LoadAlphabetsFromJSONTest
    {
        private LoadAlphabetsFromJSON jsonLoader; // Instance třídy pro načítání dat z JSON
        private string alphabetsTestFilePath; // Cesta k testovacím souborům s abecedami

        /// <summary>
        /// Metoda, která se spustí před spuštěním každé testovací metody.
        /// Inicializuje instanci třídy pro načítání dat a určuje cestu k testovacím souborům.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            alphabetsTestFilePath = Path.Combine("TestResources", "Alphabets");
            jsonLoader = new LoadAlphabetsFromJSON(alphabetsTestFilePath);
        }

        /// <summary>
        /// Testovací metoda pro úspěšné načtení abeced z platného JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadAlphabetsFromJSON_Success()
        {
            string alphabetsTestFilePathValidFormat = Path.Combine(alphabetsTestFilePath, "AlphabetsValidFormat.json");

            // Načtení abeced z platného JSON souboru
            Dictionary<string, string> result = jsonLoader.LoadData(alphabetsTestFilePathValidFormat, false);

            // Ověření, že byla načtena neprázdná data (soubor byl v pořádku)
            Assert.IsNotNull(result, "The method should not return any data if the file was ok.");
        }

        /// <summary>
        /// Testuje chování, kdy není nalezen soubor s abecedami.
        /// </summary>
        [TestMethod]
        public void LoadAlphabetsFromJSON_FileNotFound()
        {
            string alphabetsTestFilePathNotFound = Path.Combine(alphabetsTestFilePath, "AlphabetsNonExistentFile.json");

            // Načtení abeced z neexistujícího souboru
            Dictionary<string, string> result = jsonLoader.LoadData(alphabetsTestFilePathNotFound, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl nalezen)
            Assert.IsNull(result, "The method should not return any data if the file was not found.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadAlphabetsFromJSON_InvalidAlphabetsFormat1()
        {
            string alphabetsTestFilePathInvalidFormat1 = Path.Combine(alphabetsTestFilePath, "AlphabetsInvalidFormat1.json");

            // Načtení abeced z neplatného JSON souboru
            Dictionary<string, string> result = jsonLoader.LoadData(alphabetsTestFilePathInvalidFormat1, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadAlphabetsFromJSON_InvalidAlphabetsFormat2()
        {
            string alphabetsTestFilePathInvalidFormat2 = Path.Combine(alphabetsTestFilePath, "AlphabetsInvalidFormat2.json");

            // Načtení abeced z neplatného JSON souboru
            Dictionary<string, string> result = jsonLoader.LoadData(alphabetsTestFilePathInvalidFormat2, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadAlphabetsFromJSON_InvalidAlphabetsFormat3()
        {
            string alphabetsTestFilePathInvalidFormat3 = Path.Combine(alphabetsTestFilePath, "AlphabetsInvalidFormat3.json");

            // Načtení abeced z neplatného JSON souboru
            Dictionary<string, string> result = jsonLoader.LoadData(alphabetsTestFilePathInvalidFormat3, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadAlphabetsFromJSON_InvalidAlphabetsFormat4()
        {
            string alphabetsTestFilePathInvalidFormat4 = Path.Combine(alphabetsTestFilePath, "AlphabetsInvalidFormat4.json");

            // Načtení abeced z neplatného JSON souboru
            Dictionary<string, string> result = jsonLoader.LoadData(alphabetsTestFilePathInvalidFormat4, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadAlphabetsFromJSON_InvalidAlphabetsFormat5()
        {
            string alphabetsTestFilePathInvalidFormat5 = Path.Combine(alphabetsTestFilePath, "AlphabetsInvalidFormat5.json");

            // Načtení abeced z neplatného JSON souboru
            Dictionary<string, string> result = jsonLoader.LoadData(alphabetsTestFilePathInvalidFormat5, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadAlphabetsFromJSON.
        /// </summary>
        [TestMethod]
        public void LoadAlphabetsFromJSON_Constructor1()
        {
            string validPath = Path.Combine(alphabetsTestFilePath, "AlphabetsValidFormat.json");

            // Inicializace instance třídy LoadAlphabetsFromJSON
            LoadAlphabetsFromJSON validLoader = new LoadAlphabetsFromJSON(validPath);

            // Ověření, že instance byla inicializována
            Assert.IsNotNull(validLoader, "The constructor should initialize the instance.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadAlphabetsFromJSON s neplatnou cestou.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadAlphabetsFromJSON_Constructor2()
        {
            // Inicializace instance třídy LoadAlphabetsFromJSON s neplatnou cestou (očekává se vyvolání výjimky ArgumentNullException)
            LoadAlphabetsFromJSON invalidLoader = new LoadAlphabetsFromJSON(null);
        }
    }
}
