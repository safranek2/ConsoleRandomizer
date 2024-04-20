using ConsoleRandomizer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Třída obsahující testy pro třídu Magic8Ball.
    /// </summary>
    [TestClass]
    public class Magic8BallTest
    {
        Magic8Ball magic8Ball; // Instance třídy Magic8Ball pro testování

        [TestInitialize]
        public void SetUp()
        {
            magic8Ball = new Magic8Ball(); // Inicializace instance třídy Magic8Ball před každým testem
        }

        /// <summary>
        /// Testuje, zda metoda GenerateAnswer vrátí nějakou odpověď ze seznamu možných odpovědí.
        /// </summary>
        [TestMethod]
        public void GenerateAnswer_ReturnsValidAnswer()
        {
            // Volání GenerateAnswer
            string answer = magic8Ball.GenerateAnswer();

            // Ověření, že vrácená odpověď není prázdná
            Assert.IsFalse(string.IsNullOrEmpty(answer));
        }
    }
}
