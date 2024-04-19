using System.Drawing;

namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Třída obsahující testy pro třídu ColorGenerator.
    /// </summary>
    [TestClass]
    public class ColorGeneratorTests
    {
        /// <summary>
        /// Testuje generování náhodné barvy.
        /// </summary>
        [TestMethod]
        public void TestGenerateRandomColor()
        {
            ColorGenerator colorGenerator = new ColorGenerator();

            string randomColor = colorGenerator.GenerateRandomColor();

            Assert.IsNotNull(randomColor);
            Assert.IsTrue(randomColor.StartsWith("#"));
            Assert.AreEqual(7, randomColor.Length); // formát #RRGGBB
        }

        /// <summary>
        /// Testuje výpočet kontrastní barvy na základě barvy pozadí.
        /// </summary>
        [TestMethod]
        public void TestCalculateContrastColor()
        {
            ColorGenerator colorGenerator = new ColorGenerator();
            Color whiteColor = Color.White;
            Color blackColor = Color.Black;

            Color contrastColorWhite = colorGenerator.CalculateContrastColor(whiteColor);
            Color contrastColorBlack = colorGenerator.CalculateContrastColor(blackColor);

            Assert.AreEqual(Color.Black, contrastColorWhite);
            Assert.AreEqual(Color.White, contrastColorBlack);
        }
    }
}
