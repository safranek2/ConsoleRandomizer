namespace ConsoleRandomizerMSTest
{
    [TestClass]
    public class LoadPasswordSettingsFromJSONTest
    {
        private LoadPasswordSettingsFromJSON jsonLoader; // Instance třídy pro načítání dat z JSON
        private string passwordSettingsTestFilePath; // Cesta k testovacím souborům s nastavením čísel

        /// <summary>
        /// Metoda, která se spustí před spuštěním každé testovací metody.
        /// Inicializuje instanci třídy pro načítání dat a určuje cestu k testovacím souborům.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            passwordSettingsTestFilePath = Path.Combine("TestResources", "PasswordSettings");
            jsonLoader = new LoadPasswordSettingsFromJSON(passwordSettingsTestFilePath);
        }

        /// <summary>
        /// Testovací metoda pro úspěšné načtení abeced z platného JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_Success()
        {
            string loadPasswordSettingsTestFilePathValidFormat = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsValidFormat.json");

            PasswordSettings result = jsonLoader.LoadData(loadPasswordSettingsTestFilePathValidFormat, false);

            Assert.IsNotNull(result, "The method should return not null data if the file was ok.");
        }

        /// <summary>
        /// Testuje chování, kdy není nalezen soubor.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_FileNotFound()
        {
            string loadPasswordSettingsTestFilePathNotFound = Path.Combine(passwordSettingsTestFilePath, "NonExistentFile.json");

            PasswordSettings result = jsonLoader.LoadData(loadPasswordSettingsTestFilePathNotFound, false);

            Assert.IsNull(result, "The method should not return any data if the file was not found.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat1()
        {
            string PasswordSettingsFilePathInvalidFormat1 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat1.json");

            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat1, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat2()
        {
            string PasswordSettingsFilePathInvalidFormat2 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat2.json");

            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat2, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat3()
        {
            string PasswordSettingsFilePathInvalidFormat3 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat3.json");

            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat3, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat4()
        {
            string PasswordSettingsFilePathInvalidFormat4 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat4.json");

            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat4, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat5()
        {
            string PasswordSettingsFilePathInvalidFormat5 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat5.json");

            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat5, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat6()
        {
            string PasswordSettingsFilePathInvalidFormat6 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat6.json");

            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat6, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat7()
        {
            string PasswordSettingsFilePathInvalidFormat7 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat7.json");

            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat7, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat8()
        {
            string PasswordSettingsFilePathInvalidFormat8 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat8.json");

            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat8, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat9()
        {
            string PasswordSettingsFilePathInvalidFormat9 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat1.json");

            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat9, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat10()
        {
            string PasswordSettingsFilePathInvalidFormat10 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat10.json");

            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat10, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat11()
        {
            string PasswordSettingsFilePathInvalidFormat11 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat11.json");

            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat11, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadPasswordSettingsFromJSON.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_Constructor1()
        {
            string validPath = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsValidFormat.json");

            LoadPasswordSettingsFromJSON validLoader = new LoadPasswordSettingsFromJSON(validPath);

            Assert.IsNotNull(validLoader, "The constructor should initialize the instance.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadPasswordSettingsFromJSON.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadPasswordSettingsFromJSON_Constructor2()
        {
            LoadPasswordSettingsFromJSON invalidLoader = new LoadPasswordSettingsFromJSON(null);
        }
    }
}
