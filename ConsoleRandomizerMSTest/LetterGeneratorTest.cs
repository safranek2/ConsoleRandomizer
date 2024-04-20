namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Třída obsahující testy pro třídu LetterGenerator.
    /// </summary>
    [TestClass]
    public class LetterGeneratorTest
    {
        LetterGenerator letterGenerator; // Instance třídy LetterGenerator pro testování

        [TestInitialize]
        public void SetUp()
        {
            letterGenerator = new LetterGenerator(); // Inicializace instance třídy LetterGenerator před každým testem
        }

        /// <summary>
        /// Testuje, zda je vygenerovaný náhodný znak platným znakem z abecedy.
        /// </summary>
        [TestMethod]
        public void GetChar_ValidChar()
        {
            // Testování pro anglickou abecedu
            string englishAlphabet = "abcdefghijklmnopqrstuvwxyz";

            // Generuje náhodný znak z anglické abecedy
            char generatedChar = letterGenerator.GetChar(englishAlphabet);

            // Ověření, že vygenerovaný znak je platný znak z abecedy
            Assert.IsTrue(englishAlphabet.Contains(generatedChar));
        }

        /// <summary>
        /// Testuje, zda je vygenerovaný náhodný znak z abecedy odpovídající délce abecedy.
        /// </summary>
        [TestMethod]
        public void GetChar_CorrectLength()
        {
            // Testování pro českou abecedu
            string czechAlphabet = "aábcčdďeéěfghiíjklmnňoópqrřsštťuúůvwxyýzž";

            // Generuje náhodný znak z české abecedy
            char generatedChar = letterGenerator.GetChar(czechAlphabet);

            // Ověření, že vygenerovaný znak je z abecedy odpovídající délce
            Assert.AreEqual(czechAlphabet.Length, czechAlphabet.Distinct().Count());
        }
    }
}
