namespace ConsoleRandomizerMSTest
{
    [TestClass]
    public class LoadNumbersSettingsFromJSONTest
    {
        private LoadNumbersSettingsFromJSON jsonLoader; // Instance třídy pro načítání dat z JSON
        private string numbersSettingsTestFilePath; // Cesta k testovacím souborům s nastavením čísel

        /// <summary>
        /// Metoda, která se spustí před spuštěním každé testovací metody.
        /// Inicializuje instanci třídy pro načítání dat a určuje cestu k testovacím souborům.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            numbersSettingsTestFilePath = Path.Combine("TestResources", "NumbersSettings");
            jsonLoader = new LoadNumbersSettingsFromJSON(numbersSettingsTestFilePath);
        }

        /// <summary>
        /// Testovací metoda pro úspěšné načtení abeced z platného JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadNumbersSettingsFromJSON_Success()
        {
            string loadNumbersSettingTestFilePathValidFormat = Path.Combine(numbersSettingsTestFilePath, "NumbersSettingsValidFormat.json");

            NumbersSettings result = jsonLoader.LoadData(loadNumbersSettingTestFilePathValidFormat, false);

            Assert.IsNotNull(result, "The method should return not null data if the file was ok.");
        }

        /// <summary>
        /// Testuje chování, kdy není nalezen soubor.
        /// </summary>
        [TestMethod]
        public void LoadNumbersSettingsFromJSON_FileNotFound()
        {
            string NumbersSettingsTestFilePathNotFound = Path.Combine(numbersSettingsTestFilePath, "NonExistentFile.json");

            NumbersSettings result = jsonLoader.LoadData(NumbersSettingsTestFilePathNotFound, false);

            Assert.IsNull(result, "The method should not return any data if the file was not found.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadNumbersSettingsFromJSON_InvalidJsonFormat1()
        {
            string NumbersSettingsTestFilePathInvalidFormat1 = Path.Combine(numbersSettingsTestFilePath, "NumbersSettingsInvalidFormat1.json");

            NumbersSettings result = jsonLoader.LoadData(NumbersSettingsTestFilePathInvalidFormat1, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadNumbersSettingsFromJSON_InvalidNumbersSettings2()
        {
            string NumbersSettingsTestFilePathInvalidFormat2 = Path.Combine(numbersSettingsTestFilePath, "NumbersSettingsInvalidFormat2.json");

            NumbersSettings result = jsonLoader.LoadData(NumbersSettingsTestFilePathInvalidFormat2, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadNumbersSettingsFromJSON_InvalidNumbersSettings3()
        {
            string NumbersSettingsTestFilePathInvalidFormat3 = Path.Combine(numbersSettingsTestFilePath, "NumbersSettingsInvalidFormat3.json");

            NumbersSettings result = jsonLoader.LoadData(NumbersSettingsTestFilePathInvalidFormat3, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadNumbersSettingsFromJSON_InvalidNumbersSettings4()
        {
            string NumbersSettingsTestFilePathInvalidFormat4 = Path.Combine(numbersSettingsTestFilePath, "NumbersSettingsInvalidFormat4.json");

            NumbersSettings result = jsonLoader.LoadData(NumbersSettingsTestFilePathInvalidFormat4, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadNumbersSettingsFromJSON_InvalidNumbersSettings5()
        {
            string NumbersSettingsTestFilePathInvalidFormat5 = Path.Combine(numbersSettingsTestFilePath, "NumbersSettingsInvalidFormat5.json");

            NumbersSettings result = jsonLoader.LoadData(NumbersSettingsTestFilePathInvalidFormat5, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadNumbersSettingsFromJSON_InvalidNumbersSettings6()
        {
            string NumbersSettingsTestFilePathInvalidFormat6 = Path.Combine(numbersSettingsTestFilePath, "NumbersSettingsInvalidFormat6.json");

            NumbersSettings result = jsonLoader.LoadData(NumbersSettingsTestFilePathInvalidFormat6, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadNumbersSettingsFromJSON.
        /// </summary>
        [TestMethod]
        public void LoadNumbersSettingsFromJSON_Constructor1()
        {
            string validPath = Path.Combine(numbersSettingsTestFilePath, "NumbersSettingsValidFormat.json");

            LoadNumbersSettingsFromJSON validLoader = new LoadNumbersSettingsFromJSON(validPath);

            Assert.IsNotNull(validLoader, "The constructor should initialize the instance.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadNumbersSettingsFromJSON.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadNumbersSettingsFromJSON_Constructor2()
        {
            LoadNumbersSettingsFromJSON invalidLoader = new LoadNumbersSettingsFromJSON(null);
        }
    }
}