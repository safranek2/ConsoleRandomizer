namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Třída obsahující testovací metody pro načítání nastavení hesel z JSON souboru.
    /// </summary>
    [TestClass]
    public class LoadPasswordSettingsFromJSONTest
    {
        private LoadPasswordSettingsFromJSON jsonLoader; // Instance třídy pro načítání dat z JSON
        private string passwordSettingsTestFilePath; // Cesta k testovacím souborům s nastavením hesel

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
        /// Testuje úspěšné načtení nastavení hesel z platného JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_Success()
        {
            string loadPasswordSettingsTestFilePathValidFormat = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsValidFormat.json");

            // Načtení nastavení hesel z platného JSON souboru
            PasswordSettings result = jsonLoader.LoadData(loadPasswordSettingsTestFilePathValidFormat, false);

            // Ověření, že byla vrácena neprázdná data (soubor byl v pořádku)
            Assert.IsNotNull(result, "The method should return not null data if the file was ok.");
        }

        /// <summary>
        /// Testuje chování, kdy není nalezen soubor s nastavením hesel.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_FileNotFound()
        {
            string loadPasswordSettingsTestFilePathNotFound = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsNonExistentFile.json");

            // Načtení nastavení hesel z neexistujícího souboru
            PasswordSettings result = jsonLoader.LoadData(loadPasswordSettingsTestFilePathNotFound, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl nalezen)
            Assert.IsNull(result, "The method should not return any data if the file was not found.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat1()
        {
            string PasswordSettingsFilePathInvalidFormat1 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat1.json");

            // Načtení nastavení hesel z neplatného JSON souboru
            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat1, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat2()
        {
            string PasswordSettingsFilePathInvalidFormat2 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat2.json");

            // Načtení nastavení hesel z neplatného JSON souboru
            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat2, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat3()
        {
            string PasswordSettingsFilePathInvalidFormat3 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat3.json");

            // Načtení nastavení hesel z neplatného JSON souboru
            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat3, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat4()
        {
            string PasswordSettingsFilePathInvalidFormat4 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat4.json");

            // Načtení nastavení hesel z neplatného JSON souboru
            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat4, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat5()
        {
            string PasswordSettingsFilePathInvalidFormat5 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat5.json");

            // Načtení nastavení hesel z neplatného JSON souboru
            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat5, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat6()
        {
            string PasswordSettingsFilePathInvalidFormat6 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat6.json");

            // Načtení nastavení hesel z neplatného JSON souboru
            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat6, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat7()
        {
            string PasswordSettingsFilePathInvalidFormat7 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat7.json");

            // Načtení nastavení hesel z neplatného JSON souboru
            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat7, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat8()
        {
            string PasswordSettingsFilePathInvalidFormat8 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat8.json");

            // Načtení nastavení hesel z neplatného JSON souboru
            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat8, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat9()
        {
            string PasswordSettingsFilePathInvalidFormat9 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat1.json");

            // Načtení nastavení hesel z neplatného JSON souboru
            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat9, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat10()
        {
            string PasswordSettingsFilePathInvalidFormat10 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat10.json");

            // Načtení nastavení hesel z neplatného JSON souboru
            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat10, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testuje chování při neplatném formátu JSON souboru.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_InvalidJsonFormat11()
        {
            string PasswordSettingsFilePathInvalidFormat11 = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsInvalidFormat11.json");

            // Načtení nastavení hesel z neplatného JSON souboru
            PasswordSettings result = jsonLoader.LoadData(PasswordSettingsFilePathInvalidFormat11, false);

            // Ověření, že nebyla vrácena žádná data (soubor nebyl v pořádku)
            Assert.IsNull(result, "The method should not return any data if the file was not ok.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadPasswordSettingsFromJSON.
        /// </summary>
        [TestMethod]
        public void LoadPasswordSettingsFromJSON_Constructor1()
        {
            string validPath = Path.Combine(passwordSettingsTestFilePath, "PasswordSettingsValidFormat.json");

            // Inicializace instance třídy LoadPasswordSettingsFromJSON
            LoadPasswordSettingsFromJSON validLoader = new LoadPasswordSettingsFromJSON(validPath);

            // Ověření, že instance byla inicializována
            Assert.IsNotNull(validLoader, "The constructor should initialize the instance.");
        }

        /// <summary>
        /// Testovací metoda pro ověření správné inicializace instance třídy LoadPasswordSettingsFromJSON s neplatnou cestou.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadPasswordSettingsFromJSON_Constructor2()
        {
            // Inicializace instance třídy LoadPasswordSettingsFromJSON s neplatnou cestou (očekává se vyvolání výjimky ArgumentNullException)
            LoadPasswordSettingsFromJSON invalidLoader = new LoadPasswordSettingsFromJSON(null);
        }
    }
}
