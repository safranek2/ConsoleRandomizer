namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Třída pro testování funkcionality třídy PasswordGenerator.
    /// </summary>
    [TestClass]
    public class PasswordGeneratorTest
    {
        PasswordGenerator passwordGenerator; // Instance třídy PasswordGenerator pro testování.

        /// <summary>
        /// Inicializuje instanci třídy PasswordGenerator před spuštěním každého testu.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            passwordGenerator = new PasswordGenerator(); // Inicializace instance třídy PasswordGenerator před každým testem.
        }

        /// <summary>
        /// Overuje, zda metoda GeneratePassword vytvori heslo s ocekavanou delkou.
        /// </summary>
        [TestMethod]
        public void GeneratePassword_CreatesPasswordWithCorrectLength()
        {
            // Očekávaná délka hesla
            int expectedLength = 8;

            // Znaky pro heslo
            Dictionary<string, string> characters = new Dictionary<string, string>
            {
                { "Upper Case Letters", "ABCDEFGHIJKLMNOPQRSTUVWXYZ" },
                { "Lower Case Letters", "abcdefghijklmnopqrstuvwxyz" },
                { "Numbers", "0123456789" },
                { "Special Signs", "!@#$%^&*()-_=+:;\"'?/,.<>{}[]|\\`~" }
            };

            // Generování hesla
            string generatedPassword = passwordGenerator.GeneratePassword(characters, expectedLength);

            // Ověření výsledku zda vygenerované heslo má správnou délku
            Assert.AreEqual(expectedLength, generatedPassword.Length);
        }

        /// <summary>
        /// Testuje, zda metoda GeneratePassword vytvoří heslo obsahující pouze povolené znaky.
        /// </summary>
        [TestMethod]
        public void GeneratePassword_CreatesPasswordWithValidCharacters()
        {
            // Délka hesla
            int length = 10;

            // Znaky pro heslo
            Dictionary<string, string> characters = new Dictionary<string, string>
            {
                { "Upper Case Letters", "ABCDEFGHIJKLMNOPQRSTUVWXYZ" }
            };

            // Generování hesla
            string generatedPassword = passwordGenerator.GeneratePassword(characters, length);

            // Ověření výsledku, zda všechny znaky ve vygenerovaném hesle jsou platné
            foreach (char character in generatedPassword)
            {
                // Získání všech povolených znaků ze slovníku characters
                string allAllowedCharacters = string.Concat(characters.Values);

                // Ověření, zda je znak povolený
                Assert.IsTrue(allAllowedCharacters.Contains(character));
            }
        }


        /// <summary>
        /// Overuje, zda metoda GetRandomChar vraci znak z daneho retezce znaku.
        /// </summary>
        [TestMethod]
        public void GetRandomChar_ReturnsCharacterFromGivenString()
        {
            // Řetězec znaků
            string characterString = "abcde";

            // Získání náhodného znaku
            char randomCharacter = passwordGenerator.GetRandomChar(characterString);

            // Ověření výsledku zda získaný znak je obsažen v řetězci znaků
            Assert.IsTrue(characterString.Contains(randomCharacter));
        }
    }
}
