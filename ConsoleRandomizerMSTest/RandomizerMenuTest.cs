namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Testovací třída pro ověření funkčnosti třídy RandomizerMenu, která představuje hlavní menu pro ovládání generátorů náhodných prvků.
    /// </summary>
    [TestClass]
    public class RandomizerMenuTest
    {
        RandomizerMenu randomizerMenu; // Instance třídy RandomizerMenu pro testování.

        /// <summary>
        /// Inicializuje instanci třídy RandomizerMenu před spuštěním každého testu.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            randomizerMenu = new RandomizerMenu(); // Inicializace instance třídy RandomizerMenu před každým testem.
        }

        /// <summary>
        /// Testuje, zda metoda GetMainMenu vrací text hlavního menu.
        /// </summary>
        [TestMethod]
        public void GetMainMenu_ReturnsMainMenuText()
        {
            // Provádění testované operace
            string mainMenu = randomizerMenu.GetMainMenu(false);

            // Ověření výstupu
            Assert.IsNotNull(mainMenu);
            Assert.IsTrue(mainMenu.Contains("Console Randomizer"));
        }

        /// <summary>
        /// Testuje, zda metoda GetRandomizerMenu vrací text podmenu s názvem zvolené funkce.
        /// </summary>
        [TestMethod]
        public void GetRandomizerMenu_ReturnsSubMenuText()
        {
            // Příprava vstupních podmínek
            string title = "Test Title"; // Název podmenu

            // Provádění testované operace
            string subMenu = randomizerMenu.GetRandomizerMenu(title, false);

            // Ověření výstupu
            Assert.IsNotNull(subMenu);
            Assert.IsTrue(subMenu.Contains("Console Randomizer")); // Zahrnuje název aplikace
            Assert.IsTrue(subMenu.Contains(title)); // Zahrnuje specifikovaný název podmenu
        }
    }
}
