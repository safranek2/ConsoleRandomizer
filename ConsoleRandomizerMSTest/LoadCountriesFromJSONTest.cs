namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// T��da obsahuj�c� testovac� metody pro na��t�n� zem� z JSON souboru.
    /// </summary>
    [TestClass]
    public class LoadCountriesFromJSONTest
    {
        private LoadCountriesFromJSON jsonLoader; // Instance t��dy pro na��t�n� dat z JSON
        private string countriesTestFilePath; // Cesta k testovac�m soubor�m se zem�mi

        /// <summary>
        /// Metoda, kter� se spust� p�ed spu�t�n�m ka�d� testovac� metody.
        /// Inicializuje instanci t��dy pro na��t�n� dat a ur�uje cestu k testovac�m soubor�m.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            countriesTestFilePath = Path.Combine("TestResources", "Countries");
            jsonLoader = new LoadCountriesFromJSON(countriesTestFilePath);
        }

        /// <summary>
        /// Testuje �sp�n� na�ten� zem� z platn�ho JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadCountriesFromJSON_Success()
        {
            string countriesTestFilePathValidFormat = Path.Combine(countriesTestFilePath, "CountriesValidFormat.json");

            // Na�ten� zem� z platn�ho JSON souboru
            List<string> result = jsonLoader.LoadData(countriesTestFilePathValidFormat, false);

            // Ov��en�, �e byla na�tena nepr�zdn� data (soubor byl v po��dku)
            Assert.IsNotNull(result, "The method should return not null data if the file was ok.");
        }

        /// <summary>
        /// Testuje chov�n�, kdy nen� nalezen soubor se zem�mi.
        /// </summary>
        [TestMethod]
        public void LoadAlphabetsFromJSON_FileNotFound()
        {
            string countriesTestFilePathNotFound = Path.Combine(countriesTestFilePath, "CountriesNonExistentFile.json");

            // Na�ten� zem� z neexistuj�c�ho souboru
            List<string> result = jsonLoader.LoadData(countriesTestFilePathNotFound, false);

            // Ov��en�, �e nebyla vr�cena ��dn� data (soubor nebyl nalezen)
            Assert.IsNull(result, "The method should not return any data if the file was not found.");
        }

        /// <summary>
        /// Testuje chov�n� p�i neplatn�m form�tu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadCountriesFromJSON_InvalidJsonFormat1()
        {
            string countriesTestFilePathInvalidFormat1 = Path.Combine(countriesTestFilePath, "CountriesInvalidFormat1.json");

            // Na�ten� zem� z platn�ho JSON souboru
            List<string> result = jsonLoader.LoadData(countriesTestFilePathInvalidFormat1, false);

            // Ov��en�, �e byla na�tena nepr�zdn� data (soubor byl v po��dku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chov�n� p�i neplatn�m form�tu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadCountriesFromJSON_InvalidJsonFormat2()
        {
            string countriesTestFilePathInvalidFormat2 = Path.Combine(countriesTestFilePath, "CountriesInvalidFormat2.json");

            // Na�ten� zem� z platn�ho JSON souboru
            List<string> result = jsonLoader.LoadData(countriesTestFilePathInvalidFormat2, false);

            // Ov��en�, �e byla na�tena nepr�zdn� data (soubor byl v po��dku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chov�n� p�i neplatn�m form�tu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadCountriesFromJSON_InvalidJsonFormat3()
        {
            string countriesTestFilePathInvalidFormat3 = Path.Combine(countriesTestFilePath, "CountriesInvalidFormat3.json");

            // Na�ten� zem� z platn�ho JSON souboru
            List<string> result = jsonLoader.LoadData(countriesTestFilePathInvalidFormat3, false);

            // Ov��en�, �e byla na�tena nepr�zdn� data (soubor byl v po��dku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chov�n� p�i neplatn�m form�tu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadCountriesFromJSON_InvalidJsonFormat4()
        {
            string countriesTestFilePathInvalidFormat4 = Path.Combine(countriesTestFilePath, "CountriesInvalidFormat4.json");

            // Na�ten� zem� z platn�ho JSON souboru
            List<string> result = jsonLoader.LoadData(countriesTestFilePathInvalidFormat4, false);

            // Ov��en�, �e byla na�tena nepr�zdn� data (soubor byl v po��dku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testovac� metoda pro ov��en� spr�vn� inicializace instance t��dy LoadCountriesFromJSON.
        /// </summary>
        [TestMethod]
        public void LoadCountriesFromJSON_Constructor1()
        {
            string validPath = Path.Combine(countriesTestFilePath, "CountriesValidFormat.json");

            // Inicializace instance t��dy LoadCountriesFromJSON
            LoadCountriesFromJSON validLoader = new LoadCountriesFromJSON(validPath);

            // Ov��en�, �e instance byla inicializov�na
            Assert.IsNotNull(validLoader, "The constructor should initialize the instance.");
        }

        /// <summary>
        /// Testovac� metoda pro ov��en� spr�vn� inicializace instance t��dy LoadCountriesFromJSON s neplatnou cestou.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadCountriesFromJSON_Constructor2()
        {
            // Inicializace instance t��dy LoadCountriesFromJSON s neplatnou cestou (o�ek�v� se vyvol�n� v�jimky ArgumentNullException)
            LoadCountriesFromJSON invalidLoader = new LoadCountriesFromJSON(null);
        }
    }
}
