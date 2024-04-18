namespace ConsoleRandomizerMSTest
{
    [TestClass]
    public class LoadTeamsSettingsFromJSONTest
    {
        private LoadTeamsSettingsFromJSON jsonLoader; // Instance třídy pro načítání dat z JSON
        private string teamsSettingsTestFilePath; // Cesta k testovacím souborům s nastavením čísel

        /// <summary>
        /// Metoda, která se spustí před spuštěním každé testovací metody.
        /// Inicializuje instanci třídy pro načítání dat a určuje cestu k testovacím souborům.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            teamsSettingsTestFilePath = Path.Combine("TestResources", "TeamsSettings");
            jsonLoader = new LoadTeamsSettingsFromJSON(teamsSettingsTestFilePath);
        }

        /// <summary>
        /// Testovací metoda pro úspěšné načtení abeced z platného JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadTeamsSettingsFromJSON_Success()
        {
            string loadTeamsSettingsTestFilePathValidFormat = Path.Combine(teamsSettingsTestFilePath, "TeamsSettingsValidFormat.json");

            TeamsSettings result = jsonLoader.LoadData(loadTeamsSettingsTestFilePathValidFormat, false);

            Assert.IsNotNull(result, "The method should return not null data if the file was ok.");
        }

        /// <summary>
        /// Testuje chování, kdy není nalezen soubor.
        /// </summary>
        [TestMethod]
        public void LoadTeamsSettingsFromJSON_FileNotFound()
        {
            string loadTeamsSettingsTestFilePathNotFound = Path.Combine(teamsSettingsTestFilePath, "NonExistentFile.json");

            TeamsSettings result = jsonLoader.LoadData(loadTeamsSettingsTestFilePathNotFound, false);

            Assert.IsNull(result, "The method should not return any data if the file was not found.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadTeamsSettingsFromJSON_InvalidJsonFormat1()
        {
            string TeamsSettingsFilePathInvalidFormat1 = Path.Combine(teamsSettingsTestFilePath, "TeamsSettingsInvalidFormat1.json");

            TeamsSettings result = jsonLoader.LoadData(TeamsSettingsFilePathInvalidFormat1, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadTeamsSettingsFromJSON_InvalidJsonFormat2()
        {
            string TeamsSettingsFilePathInvalidFormat2 = Path.Combine(teamsSettingsTestFilePath, "TeamsSettingsInvalidFormat2.json");

            TeamsSettings result = jsonLoader.LoadData(TeamsSettingsFilePathInvalidFormat2, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadTeamsSettingsFromJSON_InvalidJsonFormat3()
        {
            string TeamsSettingsFilePathInvalidFormat3 = Path.Combine(teamsSettingsTestFilePath, "TeamsSettingsInvalidFormat3.json");

            TeamsSettings result = jsonLoader.LoadData(TeamsSettingsFilePathInvalidFormat3, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadTeamsSettingsFromJSON_InvalidJsonFormat4()
        {
            string TeamsSettingsFilePathInvalidFormat4 = Path.Combine(teamsSettingsTestFilePath, "TeamsSettingsInvalidFormat4.json");

            TeamsSettings result = jsonLoader.LoadData(TeamsSettingsFilePathInvalidFormat4, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje správné vyvolání výjimky při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadTeamsSettingsFromJSON_InvalidJsonFormat5()
        {
            string TeamsSettingsFilePathInvalidFormat5 = Path.Combine(teamsSettingsTestFilePath, "TeamsSettingsInvalidFormat5.json");

            TeamsSettings result = jsonLoader.LoadData(TeamsSettingsFilePathInvalidFormat5, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadTeamsSettingsFromJSON.
        /// </summary>
        [TestMethod]
        public void LoadTeamsSettingsFromJSON_Constructor1()
        {
            string validPath = Path.Combine(teamsSettingsTestFilePath, "TeamsSettingsValidFormat.json");

            LoadTeamsSettingsFromJSON validLoader = new LoadTeamsSettingsFromJSON(validPath);

            Assert.IsNotNull(validLoader, "The constructor should initialize the instance.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadTeamsSettingsFromJSON.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadTeamsSettingsFromJSON_Constructor2()
        {
            LoadTeamsSettingsFromJSON invalidLoader = new LoadTeamsSettingsFromJSON(null);
        }
    }
}
