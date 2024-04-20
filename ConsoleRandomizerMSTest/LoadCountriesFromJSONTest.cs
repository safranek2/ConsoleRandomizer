namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Tøída obsahující testovací metody pro naèítání zemí z JSON souboru.
    /// </summary>
    [TestClass]
    public class LoadCountriesFromJSONTest
    {
        private LoadCountriesFromJSON jsonLoader; // Instance tøídy pro naèítání dat z JSON
        private string countriesTestFilePath; // Cesta k testovacím souborùm se zemìmi

        /// <summary>
        /// Metoda, která se spustí pøed spuštìním každé testovací metody.
        /// Inicializuje instanci tøídy pro naèítání dat a urèuje cestu k testovacím souborùm.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            countriesTestFilePath = Path.Combine("TestResources", "Countries");
            jsonLoader = new LoadCountriesFromJSON(countriesTestFilePath);
        }

        /// <summary>
        /// Testuje úspìšné naètení zemí z platného JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadCountriesFromJSON_Success()
        {
            string countriesTestFilePathValidFormat = Path.Combine(countriesTestFilePath, "CountriesValidFormat.json");

            // Naètení zemí z platného JSON souboru
            List<string> result = jsonLoader.LoadData(countriesTestFilePathValidFormat, false);

            // Ovìøení, že byla naètena neprázdná data (soubor byl v poøádku)
            Assert.IsNotNull(result, "The method should return not null data if the file was ok.");
        }

        /// <summary>
        /// Testuje chování, kdy není nalezen soubor se zemìmi.
        /// </summary>
        [TestMethod]
        public void LoadAlphabetsFromJSON_FileNotFound()
        {
            string countriesTestFilePathNotFound = Path.Combine(countriesTestFilePath, "CountriesNonExistentFile.json");

            // Naètení zemí z neexistujícího souboru
            List<string> result = jsonLoader.LoadData(countriesTestFilePathNotFound, false);

            // Ovìøení, že nebyla vrácena žádná data (soubor nebyl nalezen)
            Assert.IsNull(result, "The method should not return any data if the file was not found.");
        }

        /// <summary>
        /// Testuje chování pøi neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadCountriesFromJSON_InvalidJsonFormat1()
        {
            string countriesTestFilePathInvalidFormat1 = Path.Combine(countriesTestFilePath, "CountriesInvalidFormat1.json");

            // Naètení zemí z platného JSON souboru
            List<string> result = jsonLoader.LoadData(countriesTestFilePathInvalidFormat1, false);

            // Ovìøení, že byla naètena neprázdná data (soubor byl v poøádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování pøi neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadCountriesFromJSON_InvalidJsonFormat2()
        {
            string countriesTestFilePathInvalidFormat2 = Path.Combine(countriesTestFilePath, "CountriesInvalidFormat2.json");

            // Naètení zemí z platného JSON souboru
            List<string> result = jsonLoader.LoadData(countriesTestFilePathInvalidFormat2, false);

            // Ovìøení, že byla naètena neprázdná data (soubor byl v poøádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování pøi neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadCountriesFromJSON_InvalidJsonFormat3()
        {
            string countriesTestFilePathInvalidFormat3 = Path.Combine(countriesTestFilePath, "CountriesInvalidFormat3.json");

            // Naètení zemí z platného JSON souboru
            List<string> result = jsonLoader.LoadData(countriesTestFilePathInvalidFormat3, false);

            // Ovìøení, že byla naètena neprázdná data (soubor byl v poøádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování pøi neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadCountriesFromJSON_InvalidJsonFormat4()
        {
            string countriesTestFilePathInvalidFormat4 = Path.Combine(countriesTestFilePath, "CountriesInvalidFormat4.json");

            // Naètení zemí z platného JSON souboru
            List<string> result = jsonLoader.LoadData(countriesTestFilePathInvalidFormat4, false);

            // Ovìøení, že byla naètena neprázdná data (soubor byl v poøádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testovací metoda pro ovìøení správné inicializace instance tøídy LoadCountriesFromJSON.
        /// </summary>
        [TestMethod]
        public void LoadCountriesFromJSON_Constructor1()
        {
            string validPath = Path.Combine(countriesTestFilePath, "CountriesValidFormat.json");

            // Inicializace instance tøídy LoadCountriesFromJSON
            LoadCountriesFromJSON validLoader = new LoadCountriesFromJSON(validPath);

            // Ovìøení, že instance byla inicializována
            Assert.IsNotNull(validLoader, "The constructor should initialize the instance.");
        }

        /// <summary>
        /// Testovací metoda pro ovìøení správné inicializace instance tøídy LoadCountriesFromJSON s neplatnou cestou.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadCountriesFromJSON_Constructor2()
        {
            // Inicializace instance tøídy LoadCountriesFromJSON s neplatnou cestou (oèekává se vyvolání výjimky ArgumentNullException)
            LoadCountriesFromJSON invalidLoader = new LoadCountriesFromJSON(null);
        }
    }
}
