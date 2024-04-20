namespace ConsoleRandomizerMSTest
{
    [TestClass]
    public class NumbersGeneratorTest
    {
        NumbersGenerator numbersGenerator; // Deklarace instance třídy NumbersGenerator pro testování.

        [TestInitialize]
        public void SetUp()
        {
            numbersGenerator = new NumbersGenerator(); // Inicializace instance třídy NumbersGenerator před každým testem.
        }

        /// <summary>
        /// Testuje, zda metoda GenerateNumbers vygeneruje správný počet čísel.
        /// </summary>
        [TestMethod]
        public void GenerateNumbers_GeneratesCorrectNumberOfNumbers()
        {
            int count = 5; // Počet čísel, který má být vygenerován.
            int min = 1; // Minimální hodnota, která může být vygenerována.
            int max = 10; // Maximální hodnota, která může být vygenerována.
            bool repetitions = false; // Příznak, zda se čísla mohou opakovat.

            List<int> generatedNumbers = numbersGenerator.GenerateNumbers(count, min, max, repetitions); // Volání metody GenerateNumbers pro vygenerování čísel.

            Assert.AreEqual(count, generatedNumbers.Count); // Ověření, zda počet vygenerovaných čísel odpovídá očekávanému počtu.
        }

        /// <summary>
        /// Testuje, zda metoda GenerateNumbers generuje čísla v správném rozsahu.
        /// </summary>
        [TestMethod]
        public void GenerateNumbers_GeneratesNumbersInRange()
        {
            int count = 10; // Počet čísel, který má být vygenerován.
            int min = 1; // Minimální hodnota, která může být vygenerována.
            int max = 10; // Maximální hodnota, která může být vygenerována.
            bool repetitions = false; // Příznak, zda se čísla mohou opakovat.

            List<int> generatedNumbers = numbersGenerator.GenerateNumbers(count, min, max, repetitions); // Volání metody GenerateNumbers pro vygenerování čísel.

            foreach (int number in generatedNumbers) // Projde vygenerovaná čísla.
            {
                Assert.IsTrue(number >= min && number <= max); // Ověří, zda každé vygenerované číslo je v rozsahu od min do max (včetně).
            }
        }

        /// <summary>
        /// Testuje, zda metoda GenerateNumbers generuje unikátní čísla, pokud opakování není povoleno.
        /// </summary>
        [TestMethod]
        public void GenerateNumbers_GeneratesUniqueNumbersIfNoRepetitions()
        {
            int count = 10; // Počet čísel, který má být vygenerován.
            int min = 1; // Minimální hodnota, která může být vygenerována.
            int max = 10; // Maximální hodnota, která může být vygenerována.
            bool repetitions = false; // Příznak, zda se čísla mohou opakovat.

            List<int> generatedNumbers = numbersGenerator.GenerateNumbers(count, min, max, repetitions); // Volání metody GenerateNumbers pro vygenerování čísel.

            CollectionAssert.AllItemsAreUnique(generatedNumbers); // Ověří, zda jsou všechna vygenerovaná čísla unikátní.
        }

        /// <summary>
        /// Testuje, zda metoda GenerateNumbers generuje čísla s opakováním, pokud je povoleno.
        /// </summary>
        [TestMethod]
        public void GenerateNumbers_GeneratesNumbersWithRepetitionsIfAllowed()
        {
            int count = 10; // Počet čísel, který má být vygenerován.
            int min = 1; // Minimální hodnota, která může být vygenerována.
            int max = 10; // Maximální hodnota, která může být vygenerována.
            bool repetitions = true; // Příznak, zda se čísla mohou opakovat.

            List<int> generatedNumbers = numbersGenerator.GenerateNumbers(count, min, max, repetitions); // Volání metody GenerateNumbers pro vygenerování čísel.

            Assert.AreEqual(count, generatedNumbers.Count); // Ověří, zda počet vygenerovaných čísel odpovídá očekávanému počtu.
        }
    }
}
