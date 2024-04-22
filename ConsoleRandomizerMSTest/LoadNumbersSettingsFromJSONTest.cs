namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Třída obsahující testovací metody pro načítání nastavení čísel z JSON souboru.
    /// </summary>
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
        /// Testuje úspěšné načtení nastavení čísel z platného JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadNumbersSettingsFromJSON_Success()
        {
            string loadNumbersSettingTestFilePathValidFormat = Path.Combine(numbersSettingsTestFilePath, "NumbersSettingsValidFormat.json");

            // Načtení nastavení čísel z platného JSON souboru
            NumbersSettings result = jsonLoader.LoadData(loadNumbersSettingTestFilePathValidFormat, false);

            // Ověření, že byla vrácena neprázdná data (soubor byl v pořádku)
            Assert.IsNotNull(result, "The method should return not null data if the file was ok.");
        }

        /// <summary>
        /// Testuje chování, kdy není nalezen soubor s nastavením čísel.
        /// </summary>
        [TestMethod]
        public void LoadNumbersSettingsFromJSON_FileNotFound()
        {
            string NumbersSettingsTestFilePathNotFound = Path.Combine(numbersSettingsTestFilePath, "NumbersSettingsNonExistentFile.json");

            // Načtení nastavení čísel z neexistujícího souboru
            NumbersSettings result = jsonLoader.LoadData(NumbersSettingsTestFilePathNotFound, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl nalezen)
            Assert.IsNull(result, "The method should not return any data if the file was not found.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadNumbersSettingsFromJSON_InvalidJsonFormat1()
        {
            string NumbersSettingsTestFilePathInvalidFormat1 = Path.Combine(numbersSettingsTestFilePath, "NumbersSettingsInvalidFormat1.json");

            // Načtení nastavení čísel z neplatného JSON souboru
            NumbersSettings result = jsonLoader.LoadData(NumbersSettingsTestFilePathInvalidFormat1, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "Metoda by neměla vrátit žádná data, pokud soubor nebyl v pořádku.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadNumbersSettingsFromJSON_InvalidNumbersSettings2()
        {
            string NumbersSettingsTestFilePathInvalidFormat2 = Path.Combine(numbersSettingsTestFilePath, "NumbersSettingsInvalidFormat2.json");

            // Načtení nastavení čísel z neplatného JSON souboru
            NumbersSettings result = jsonLoader.LoadData(NumbersSettingsTestFilePathInvalidFormat2, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadNumbersSettingsFromJSON_InvalidNumbersSettings3()
        {
            string NumbersSettingsTestFilePathInvalidFormat3 = Path.Combine(numbersSettingsTestFilePath, "NumbersSettingsInvalidFormat3.json");

            // Načtení nastavení čísel z neplatného JSON souboru
            NumbersSettings result = jsonLoader.LoadData(NumbersSettingsTestFilePathInvalidFormat3, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadNumbersSettingsFromJSON_InvalidNumbersSettings4()
        {
            string NumbersSettingsTestFilePathInvalidFormat4 = Path.Combine(numbersSettingsTestFilePath, "NumbersSettingsInvalidFormat4.json");

            // Načtení nastavení čísel z neplatného JSON souboru
            NumbersSettings result = jsonLoader.LoadData(NumbersSettingsTestFilePathInvalidFormat4, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadNumbersSettingsFromJSON_InvalidNumbersSettings5()
        {
            string NumbersSettingsTestFilePathInvalidFormat5 = Path.Combine(numbersSettingsTestFilePath, "NumbersSettingsInvalidFormat5.json");

            // Načtení nastavení čísel z neplatného JSON souboru
            NumbersSettings result = jsonLoader.LoadData(NumbersSettingsTestFilePathInvalidFormat5, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadNumbersSettingsFromJSON_InvalidNumbersSettings6()
        {
            string NumbersSettingsTestFilePathInvalidFormat6 = Path.Combine(numbersSettingsTestFilePath, "NumbersSettingsInvalidFormat6.json");

            // Načtení nastavení čísel z neplatného JSON souboru
            NumbersSettings result = jsonLoader.LoadData(NumbersSettingsTestFilePathInvalidFormat6, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadNumbersSettingsFromJSON.
        /// </summary>
        [TestMethod]
        public void LoadNumbersSettingsFromJSON_Constructor1()
        {
            string validPath = Path.Combine(numbersSettingsTestFilePath, "NumbersSettingsValidFormat.json");

            // Inicializace instance třídy LoadNumbersSettingsFromJSON
            LoadNumbersSettingsFromJSON validLoader = new LoadNumbersSettingsFromJSON(validPath);

            // Ověření, že instance byla inicializována
            Assert.IsNotNull(validLoader, "The constructor should initialize the instance.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadNumbersSettingsFromJSON s neplatnou cestou.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadNumbersSettingsFromJSON_Constructor2()
        {
            // Inicializace instance třídy LoadNumbersSettingsFromJSON s neplatnou cestou (očekává se vyvolání výjimky ArgumentNullException)
            LoadNumbersSettingsFromJSON invalidLoader = new LoadNumbersSettingsFromJSON(null);
        }
    }
}
