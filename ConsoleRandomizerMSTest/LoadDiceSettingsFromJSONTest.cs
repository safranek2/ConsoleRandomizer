namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Třída obsahující testovací metody pro načítání nastavení kostek z JSON souboru.
    /// </summary>
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
        /// Testuje úspěšné načtení nastavení kostek z platného JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_Success()
        {
            string diceSettingsTestFilePathValidFormat = Path.Combine(diceSettingsTestFilePath, "DiceSettingsValidFormat.json");

            // Načtení nastavení kostek z platného JSON souboru
            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathValidFormat);

            // Ověření, že byla načtena neprázdná data (soubor byl v pořádku)
            Assert.IsNotNull(result, "The method should return not null data if the file was ok.");
        }

        /// <summary>
        /// Testuje chování, kdy není nalezen soubor s nastavením kostek.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_FileNotFound()
        {
            string diceSettingsTestFilePathNotFound = Path.Combine(diceSettingsTestFilePath, "DiceSettingsNonExistentFile.json");

            // Načtení nastavení kostek z neexistujícího souboru
            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathNotFound, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl nalezen)
            Assert.IsNull(result, "The method should not return any data if the file was not found.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_InvalidJsonFormat1()
        {
            string diceSettingsTestFilePathInvalidFormat1 = Path.Combine(diceSettingsTestFilePath, "DiceSettingsInvalidFormat1.json");

            // Načtení nastavení kostek z platného JSON souboru
            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathInvalidFormat1, false);

            // Ověření, že byla načtena neprázdná data (soubor byl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_InvalidDiceSettings2()
        {
            string diceSettingsTestFilePathInvalidFormat2 = Path.Combine(diceSettingsTestFilePath, "DiceSettingsInvalidFormat2.json");

            // Načtení nastavení kostek z platného JSON souboru
            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathInvalidFormat2, false);

            // Ověření, že byla načtena neprázdná data (soubor byl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_InvalidDiceSettings3()
        {
            string diceSettingsTestFilePathInvalidFormat3 = Path.Combine(diceSettingsTestFilePath, "DiceSettingsInvalidFormat3.json");

            // Načtení nastavení kostek z platného JSON souboru
            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathInvalidFormat3, false);

            // Ověření, že byla načtena neprázdná data (soubor byl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_InvalidDiceSettings4()
        {
            string diceSettingsTestFilePathInvalidFormat4 = Path.Combine(diceSettingsTestFilePath, "DiceSettingsInvalidFormat4.json");

            // Načtení nastavení kostek z platného JSON souboru
            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathInvalidFormat4, false);

            // Ověření, že byla načtena neprázdná data (soubor byl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_InvalidDiceSettings5()
        {
            string diceSettingsTestFilePathInvalidFormat5 = Path.Combine(diceSettingsTestFilePath, "DiceSettingsInvalidFormat5.json");

            // Načtení nastavení kostek z platného JSON souboru
            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathInvalidFormat5, false);

            // Ověření, že byla načtena neprázdná data (soubor byl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_InvalidDiceSettings6()
        {
            string diceSettingsTestFilePathInvalidFormat6 = Path.Combine(diceSettingsTestFilePath, "DiceSettingsInvalidFormat6.json");

            // Načtení nastavení kostek z platného JSON souboru
            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathInvalidFormat6, false);

            // Ověření, že byla načtena neprázdná data (soubor byl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_InvalidDiceSettings7()
        {
            string diceSettingsTestFilePathInvalidFormat7 = Path.Combine(diceSettingsTestFilePath, "DiceSettingsInvalidFormat7.json");

            // Načtení nastavení kostek z platného JSON souboru
            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathInvalidFormat7, false);

            // Ověření, že byla načtena neprázdná data (soubor byl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_InvalidDiceSettings8()
        {
            string diceSettingsTestFilePathInvalidFormat8 = Path.Combine(diceSettingsTestFilePath, "DiceSettingsInvalidFormat8.json");

            // Načtení nastavení kostek z platného JSON souboru
            DiceSettings result = jsonLoader.LoadData(diceSettingsTestFilePathInvalidFormat8, false);

            // Ověření, že byla načtena neprázdná data (soubor byl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadDiceSettingsFromJSON.
        /// </summary>
        [TestMethod]
        public void LoadDiceSettingsFromJSON_Constructor1()
        {
            string validPath = Path.Combine(diceSettingsTestFilePath, "DiceSettingsValidFormat.json");

            // Inicializace instance třídy LoadDiceSettingsFromJSON
            LoadDiceSettingsFromJSON validLoader = new LoadDiceSettingsFromJSON(validPath);

            // Ověření, že instance byla inicializována
            Assert.IsNotNull(validLoader, "The constructor should initialize the instance.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadDiceSettingsFromJSON s neplatnou cestou.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadDiceSettingsFromJSON_Constructor2()
        {
            // Inicializace instance třídy LoadDiceSettingsFromJSON s neplatnou cestou (očekává se vyvolání výjimky ArgumentNullException)
            LoadDiceSettingsFromJSON invalidLoader = new LoadDiceSettingsFromJSON(null);
        }
    }
}