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

            Dictionary<string, string> result = jsonLoader.LoadData(alphabetsTestFilePathValidFormat, false);

            Assert.IsNotNull(result, "The method should return not null data if the file was ok.");
        }

        /// <summary>
        /// Testovací metoda ověřující správné vyvolání výjimky při získání neplatného formátu abeced z JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadAlphabetsFromJSON_FileNotFound()
        {
            string alphabetsTestFilePathNotFound = Path.Combine(alphabetsTestFilePath, "NonExistentFile.json");

            Dictionary<string, string> result = jsonLoader.LoadData(alphabetsTestFilePathNotFound, false);

            Assert.IsNull(result, "The method should not return any data if the file was not found.");
        }

        /// <summary>
        /// Testovací metoda ověřující správné vyvolání výjimky při získání neplatného formátu abeced z JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadAlphabetsFromJSON_InvalidAlphabetsFormat1()
        {
            string alphabetsTestFilePathInvalidFormat1 = Path.Combine(alphabetsTestFilePath, "AlphabetsInvalidFormat1.json");

            Dictionary<string, string> result = jsonLoader.LoadData(alphabetsTestFilePathInvalidFormat1, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testovací metoda ověřující správné vyvolání výjimky při získání neplatného formátu abeced z JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadAlphabetsFromJSON_InvalidAlphabetsFormat2()
        {
            string alphabetsTestFilePathInvalidFormat2 = Path.Combine(alphabetsTestFilePath, "AlphabetsInvalidFormat2.json");

            Dictionary<string, string> result = jsonLoader.LoadData(alphabetsTestFilePathInvalidFormat2, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }



        /// <summary>
        /// Testovací metoda ověřující správné vyvolání výjimky při získání neplatného formátu abeced z JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadAlphabetsFromJSON_InvalidAlphabetsFormat3()
        {
            string alphabetsTestFilePathInvalidFormat3 = Path.Combine(alphabetsTestFilePath, "AlphabetsInvalidFormat3.json");

            Dictionary<string, string> result = jsonLoader.LoadData(alphabetsTestFilePathInvalidFormat3, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }


        /// <summary>
        /// Testovací metoda ověřující správné vyvolání výjimky při získání neplatného formátu abeced z JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadAlphabetsFromJSON_InvalidAlphabetsFormat4()
        {
            string alphabetsTestFilePathInvalidFormat4 = Path.Combine(alphabetsTestFilePath, "AlphabetsInvalidFormat4.json");

            Dictionary<string, string> result = jsonLoader.LoadData(alphabetsTestFilePathInvalidFormat4, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testovací metoda ověřující správné vyvolání výjimky při získání neplatného formátu abeced z JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadAlphabetsFromJSON_InvalidAlphabetsFormat5()
        {
            string alphabetsTestFilePathInvalidFormat5 = Path.Combine(alphabetsTestFilePath, "AlphabetsInvalidFormat5.json");

            Dictionary<string, string> result = jsonLoader.LoadData(alphabetsTestFilePathInvalidFormat5, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testovací metoda ověřující správné vyvolání výjimky při získání neplatného formátu abeced z JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadAlphabetsFromJSON_InvalidAlphabetsFormat6()
        {
            string alphabetsTestFilePathInvalidFormat6 = Path.Combine(alphabetsTestFilePath, "AlphabetsInvalidFormat6.json");

            Dictionary<string, string> result = jsonLoader.LoadData(alphabetsTestFilePathInvalidFormat6, false);

        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadAlphabetsFromJSON.
        /// </summary>
        [TestMethod]
        public void LoadAlphabetsFromJSON_Constructor1()
        {
            string validPath = Path.Combine(alphabetsTestFilePath, "AlphabetsValidFormat.json");

            LoadAlphabetsFromJSON validLoader = new LoadAlphabetsFromJSON(validPath);

            Assert.IsNotNull(validLoader, "The constructor should initialize the instance.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadAlphabetsFromJSON.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadAlphabetsFromJSON_Constructor2()
        {
            LoadAlphabetsFromJSON invalidLoader = new LoadAlphabetsFromJSON(null);
        }
    }
}
