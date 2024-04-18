namespace ConsoleRandomizerMSTest
{
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

            List<string> result = jsonLoader.LoadData(countriesTestFilePathValidFormat, false);

            Assert.IsNotNull(result, "The method should return not null data if the file was ok.");
        }

        /// <summary>
        /// Testuje chov�n�, kdy nen� nalezen soubor.
        /// </summary>
        [TestMethod]
        public void LoadCountriesFromJSON_FileNot()
        {
            string countriesTestFilePathNotFound = Path.Combine(countriesTestFilePath, "NonExistentFile.json");

            List<string> result = jsonLoader.LoadData(countriesTestFilePathNotFound, false);

            Assert.IsNull(result, "The method should not return any data if the file was not found.");
        }

        /// <summary>
        /// Testuje spr�vn� vyvol�n� v�jimky p�i neplatn�m form�tu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadCountriesFromJSON_InvalidJsonFormat1()
        {
            string countriesTestFilePathInvalidFormat1 = Path.Combine(countriesTestFilePath, "CountriesInvalidFormat1.json");

            List<string> result = jsonLoader.LoadData(countriesTestFilePathInvalidFormat1, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje spr�vn� vyvol�n� v�jimky p�i neplatn�m form�tu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadCountriesFromJSON_InvalidJsonFormat2()
        {
            string countriesTestFilePathInvalidFormat2 = Path.Combine(countriesTestFilePath, "CountriesInvalidFormat2.json");

            List<string> result = jsonLoader.LoadData(countriesTestFilePathInvalidFormat2, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje spr�vn� vyvol�n� v�jimky p�i neplatn�m form�tu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadCountriesFromJSON_InvalidJsonFormat3()
        {
            string countriesTestFilePathInvalidFormat3 = Path.Combine(countriesTestFilePath, "CountriesInvalidFormat3.json");

            List<string> result = jsonLoader.LoadData(countriesTestFilePathInvalidFormat3, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje spr�vn� vyvol�n� v�jimky p�i neplatn�m form�tu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadCountriesFromJSON_InvalidJsonFormat4()
        {
            string countriesTestFilePathInvalidFormat4 = Path.Combine(countriesTestFilePath, "CountriesInvalidFormat4.json");

            List<string> result = jsonLoader.LoadData(countriesTestFilePathInvalidFormat4, false);

            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testovac� metoda pro ov��en� spr�vn� inicializace instance t��dy LoadCountriesFromJSON.
        /// </summary>
        [TestMethod]
        public void LoadCountriesFromJSON_Constructor1()
        {
            string validPath = Path.Combine(countriesTestFilePath, "CountriesValidFormat.json");

            LoadCountriesFromJSON validLoader = new LoadCountriesFromJSON(validPath);

            Assert.IsNotNull(validLoader, "The constructor should initialize the instance.");
        }

        /// <summary>
        /// Testovac� metoda pro ov��en� spr�vn� inicializace instance t��dy LoadCountriesFromJSON.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadCountriesFromJSON_Constructor2()
        {
            LoadCountriesFromJSON invalidLoader = new LoadCountriesFromJSON(null);
        }
    }
}