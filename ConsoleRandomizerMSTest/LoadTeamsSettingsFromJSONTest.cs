namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Třída obsahující testovací metody pro načítání nastavení týmů z JSON souboru.
    /// </summary>
    [TestClass]
    public class LoadTeamsSettingsFromJSONTest
    {
        private LoadTeamsSettingsFromJSON jsonLoader; // Instance třídy pro načítání dat z JSON
        private string teamsSettingsTestFilePath; // Cesta k testovacím souborům s nastavením týmů

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
        /// Testuje úspěšné načtení nastavení týmů z platného JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadTeamsSettingsFromJSON_Success()
        {
            string loadTeamsSettingsTestFilePathValidFormat = Path.Combine(teamsSettingsTestFilePath, "TeamsSettingsValidFormat.json");

            // Načtení nastavení týmů z platného JSON souboru
            TeamsSettings result = jsonLoader.LoadData(loadTeamsSettingsTestFilePathValidFormat, false);

            // Ověření, že byla vrácena neprázdná data (soubor byl v pořádku)
            Assert.IsNotNull(result, "The method should return not null data if the file was ok.");
        }

        /// <summary>
        /// Testuje chování, kdy není nalezen soubor s nastavením týmů.
        /// </summary>
        [TestMethod]
        public void LoadTeamsSettingsFromJSON_FileNotFound()
        {
            string loadTeamsSettingsTestFilePathNotFound = Path.Combine(teamsSettingsTestFilePath, "NonExistentFile.json");

            // Načtení nastavení týmů z neexistujícího souboru
            TeamsSettings result = jsonLoader.LoadData(loadTeamsSettingsTestFilePathNotFound, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl nalezen)
            Assert.IsNull(result, "The method should not return any data if the file was not found.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadTeamsSettingsFromJSON_InvalidJsonFormat1()
        {
            string TeamsSettingsFilePathInvalidFormat1 = Path.Combine(teamsSettingsTestFilePath, "TeamsSettingsInvalidFormat1.json");

            // Načtení nastavení týmů z neplatného JSON souboru
            TeamsSettings result = jsonLoader.LoadData(TeamsSettingsFilePathInvalidFormat1, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadTeamsSettingsFromJSON_InvalidJsonFormat2()
        {
            string TeamsSettingsFilePathInvalidFormat2 = Path.Combine(teamsSettingsTestFilePath, "TeamsSettingsInvalidFormat2.json");

            // Načtení nastavení týmů z neplatného JSON souboru
            TeamsSettings result = jsonLoader.LoadData(TeamsSettingsFilePathInvalidFormat2, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadTeamsSettingsFromJSON_InvalidJsonFormat3()
        {
            string TeamsSettingsFilePathInvalidFormat3 = Path.Combine(teamsSettingsTestFilePath, "TeamsSettingsInvalidFormat3.json");

            // Načtení nastavení týmů z neplatného JSON souboru
            TeamsSettings result = jsonLoader.LoadData(TeamsSettingsFilePathInvalidFormat3, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadTeamsSettingsFromJSON_InvalidJsonFormat4()
        {
            string TeamsSettingsFilePathInvalidFormat4 = Path.Combine(teamsSettingsTestFilePath, "TeamsSettingsInvalidFormat4.json");

            // Načtení nastavení týmů z neplatného JSON souboru
            TeamsSettings result = jsonLoader.LoadData(TeamsSettingsFilePathInvalidFormat4, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadTeamsSettingsFromJSON_InvalidJsonFormat5()
        {
            string TeamsSettingsFilePathInvalidFormat5 = Path.Combine(teamsSettingsTestFilePath, "TeamsSettingsInvalidFormat5.json");

            // Načtení nastavení týmů z neplatného JSON souboru
            TeamsSettings result = jsonLoader.LoadData(TeamsSettingsFilePathInvalidFormat5, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadTeamsSettingsFromJSON.
        /// </summary>
        [TestMethod]
        public void LoadTeamsSettingsFromJSON_Constructor1()
        {
            string validPath = Path.Combine(teamsSettingsTestFilePath, "TeamsSettingsValidFormat.json");

            // Inicializace instance třídy LoadTeamsSettingsFromJSON
            LoadTeamsSettingsFromJSON validLoader = new LoadTeamsSettingsFromJSON(validPath);

            // Ověření, že instance byla inicializována
            Assert.IsNotNull(validLoader, "The constructor should initialize the instance.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadTeamsSettingsFromJSON s neplatnou cestou.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadTeamsSettingsFromJSON_Constructor2()
        {
            // Inicializace instance třídy LoadTeamsSettingsFromJSON s neplatnou cestou (očekává se vyvolání výjimky ArgumentNullException)
            LoadTeamsSettingsFromJSON invalidLoader = new LoadTeamsSettingsFromJSON(null);
        }
    }
}
