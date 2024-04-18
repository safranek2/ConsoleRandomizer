namespace ConsoleRandomizerMSTest
{
    [TestClass]
    public class LoadDiceSettingsFromJSONTest
    {
        private LoadDiceSettingsFromJSON jsonLoader; // Instance třídy pro načítání dat z JSON
        private string diceSettingsTestFilePath; // Cesta k testovacím souborům s nastavením kostek

        /// <summary>
        /// Metoda, která se spustí před spuštěním každé testovací metody.
        /// Inicializuje instanci třídy pro načítání dat a určuje cestu k testovacím souborům.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            diceSettingsTestFilePath = Path.Combine("TestResources", "DiceSettings");
            jsonLoader = new LoadDiceSettingsFromJSON(diceSettingsTestFilePath);
        }

        /// <summary>
        /// Testuje úspěšné načtení zemí z platného JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_Success()
        {
            string diceSettingsTestFilePathValidFormat = Path.Combine(diceSettingsTestFilePath, "DiceSettingsValidFormat.json");

            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathValidFormat);

            Assert.IsNotNull(result, "The method should return not null data if the file was ok.");
        }

        /// <summary>
        /// Testuje chování, kdy není nalezen soubor.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_FileNotFound()
        {
            string diceSettingsTestFilePathNotFound = Path.Combine(diceSettingsTestFilePath, "NonExistentFile.json");

            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathNotFound, false);

            Assert.IsNull(result, "The method should not return any data if the file was not found.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_InvalidJsonFormat1()
        {
            string diceSettingsTestFilePathInvalidFormat1 = Path.Combine(diceSettingsTestFilePath, "DiceSettingsInvalidFormat1.json");

            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathInvalidFormat1, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_InvalidDiceSettings2()
        {
            string diceSettingsTestFilePathInvalidFormat2 = Path.Combine(diceSettingsTestFilePath, "DiceSettingsInvalidFormat2.json");

            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathInvalidFormat2, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_InvalidDiceSettings3()
        {
            string diceSettingsTestFilePathInvalidFormat3 = Path.Combine(diceSettingsTestFilePath, "DiceSettingsInvalidFormat3.json");

            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathInvalidFormat3, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_InvalidDiceSettings4()
        {
            string diceSettingsTestFilePathInvalidFormat4 = Path.Combine(diceSettingsTestFilePath, "DiceSettingsInvalidFormat4.json");

            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathInvalidFormat4, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_InvalidDiceSettings5()
        {
            string diceSettingsTestFilePathInvalidFormat5 = Path.Combine(diceSettingsTestFilePath, "DiceSettingsInvalidFormat5.json");

            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathInvalidFormat5, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_InvalidDiceSettings6()
        {
            string diceSettingsTestFilePathInvalidFormat6 = Path.Combine(diceSettingsTestFilePath, "DiceSettingsInvalidFormat6.json");

            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathInvalidFormat6, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_InvalidDiceSettings7()
        {
            string diceSettingsTestFilePathInvalidFormat7 = Path.Combine(diceSettingsTestFilePath, "DiceSettingsInvalidFormat7.json");

            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathInvalidFormat7, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_InvalidDiceSettings8()
        {
            string diceSettingsTestFilePathInvalidFormat8 = Path.Combine(diceSettingsTestFilePath, "DiceSettingsInvalidFormat8.json");

            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathInvalidFormat8, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadDiceSettingsFromJSON.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_Constructor1()
        {
            string validPath = Path.Combine(diceSettingsTestFilePath, "DiceSettingsValidFormat.json");

            LoadDiceSettingsFromJSON validLoader = new LoadDiceSettingsFromJSON(validPath);

            Assert.IsNotNull(validLoader, "The constructor should initialize the instance.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadDiceSettingsFromJSON.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadDiceSettingsFromJSON_Constructor2()
        {
            LoadDiceSettingsFromJSON invalidLoader = new LoadDiceSettingsFromJSON(null);
        }
    }
}
