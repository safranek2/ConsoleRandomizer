using System.Drawing;

namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Třída obsahující testy pro třídu ColorGenerator.
    /// </summary>
    [TestClass]
    public class ColorGeneratorTests
    {
        ColorGenerator colorGenerator; // Instance třídy ColorGenerator pro testování

        [TestInitialize]
        public void SetUp()
        {
            colorGenerator = new ColorGenerator(); // Inicializace instance třídy ColorGenerator před každým testem
        }

        /// <summary>
        /// Testuje generování náhodné barvy.
        /// </summary>
        [TestMethod]
        public void TestGenerateRandomColor()
        {
            string randomColor = colorGenerator.GenerateRandomColor(); // Generování náhodné barvy

            // Ověření, že výsledná barva není null, začíná symbolem "#" a má délku 7 znaků (formát #RRGGBB)
            Assert.IsNotNull(randomColor);
            Assert.IsTrue(randomColor.StartsWith("#"));
            Assert.AreEqual(7, randomColor.Length);
        }

        /// <summary>
        /// Testuje výpočet kontrastní barvy na základě barvy pozadí.
        /// </summary>
        [TestMethod]
        public void TestCalculateContrastColor()
        {
            Color whiteColor = Color.White;
            Color blackColor = Color.Black;

            // Výpočet kontrastní barvy pro bílé a černé pozadí
            Color contrastColorWhite = colorGenerator.CalculateContrastColor(whiteColor);
            Color contrastColorBlack = colorGenerator.CalculateContrastColor(blackColor);

            // Ověření, že kontrastní barva pro bílé pozadí je černá a pro černé pozadí je bílá
            Assert.AreEqual(Color.Black, contrastColorWhite);
            Assert.AreEqual(Color.White, contrastColorBlack);
        }
    }
}
