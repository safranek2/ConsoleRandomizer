namespace ConsoleRandomizerMSTest
{
    [TestClass]
    public class LoadMagic8BallAnswersFromJSONTest
    {
        private LoadMagic8BallAnswersFromJSON jsonLoader; // Instance třídy pro načítání dat z JSON
        private string magic8BallAnswersTestFilePath; // Cesta k testovacím souborům s odpověďmi do magické koule

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
        /// Testuje úspěšné načtení zemí z platného JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadMagic8BallAnswersFromJSON_Success()
        {
            string magic8BallAnswersTestFilePathValidFormat = Path.Combine(magic8BallAnswersTestFilePath, "Magic8BallAnswersValidFormat.json");

            List<string> result = jsonLoader.LoadData(magic8BallAnswersTestFilePathValidFormat, false);

            Assert.IsNotNull(result, "The method should return not null data if the file was ok.");
        }

        /// <summary>
        /// Testuje chování, kdy není nalezen soubor.
        /// </summary>
        [TestMethod]
        public void LoadMagic8BallAnswersFromJSON_FileNot()
        {
            string magic8BallAnswersTestFilePathNotFound = Path.Combine(magic8BallAnswersTestFilePath, "Magic8BallAnswersNonExistentFile.json");

            List<string> result = jsonLoader.LoadData(magic8BallAnswersTestFilePathNotFound, false);

            Assert.IsNull(result, "The method should not return any data if the file was not found.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadMagic8BallAnswersFromJSON_InvalidJsonFormat()
        {
            string magic8BallAnswersTestFilePathInvalidFormat = Path.Combine(magic8BallAnswersTestFilePath, "Magic8BallAnswersInvalidFormat.json");

            List<string> result = jsonLoader.LoadData(magic8BallAnswersTestFilePathInvalidFormat, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadMagic8BallAnswersFromJSON_InvalidJsonFormat2()
        {
            string magic8BallAnswersTestFilePathInvalidFormat2 = Path.Combine(magic8BallAnswersTestFilePath, "Magic8BallAnswersInvalidFormat2.json");

            List<string> result = jsonLoader.LoadData(magic8BallAnswersTestFilePathInvalidFormat2, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadMagic8BallAnswersFromJSON_InvalidJsonFormat3()
        {
            string magic8BallAnswersTestFilePathInvalidFormat3 = Path.Combine(magic8BallAnswersTestFilePath, "Magic8BallAnswersInvalidFormat3.json");

            List<string> result = jsonLoader.LoadData(magic8BallAnswersTestFilePathInvalidFormat3, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadMagic8BallAnswersFromJSON_InvalidJsonFormat4()
        {
            string magic8BallAnswersTestFilePathInvalidFormat4 = Path.Combine(magic8BallAnswersTestFilePath, "Magic8BallAnswersInvalidFormat4.json");

            List<string> result = jsonLoader.LoadData(magic8BallAnswersTestFilePathInvalidFormat4, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadMagic8BallAnswersFromJSON.
        /// </summary>
        [TestMethod]
        public void LoadMagic8BallAnswersFromJSON_Constructor1()
        {
            string validPath = Path.Combine(magic8BallAnswersTestFilePath, "Magic8BallAnswersValidFormat.json");

            LoadMagic8BallAnswersFromJSON validLoader = new LoadMagic8BallAnswersFromJSON(validPath);

            Assert.IsNotNull(validLoader, "The constructor should initialize the instance.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadMagic8BallAnswersFromJSON.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadMagic8BallAnswersFromJSON_Constructor2()
        {
            LoadMagic8BallAnswersFromJSON invalidLoader = new LoadMagic8BallAnswersFromJSON(null);
        }
    }
}