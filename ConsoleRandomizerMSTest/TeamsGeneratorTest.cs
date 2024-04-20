namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Testovací třída pro funkčnost třídy TeamsGenerator.
    /// </summary>
    [TestClass]
    public class TeamsGeneratorTest
    {
        TeamsGenerator teamsGenerator; // Instance třídy TeamsGenerator pro testování.

        /// <summary>
        /// Inicializuje instanci třídy TeamsGenerator před spuštěním každého testu.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            teamsGenerator = new TeamsGenerator(); // Inicializace instance třídy TeamsGenerator před každým testem.
        }

        /// <summary>
        /// Testuje přidání jména do seznamu jmen pro týmy.
        /// </summary>
        [TestMethod]
        public void AddName_AddsNameToList()
        {
            // Příprava vstupních dat
            List<string> names = new List<string>();
            string nameToAdd = "John Doe";

            // Provádění testované operace
            teamsGenerator.AddName(names, nameToAdd);

            // Kontrola jestli list obsahuje nové jméno
            CollectionAssert.Contains(names, nameToAdd);
        }

        /// <summary>
        /// Testuje vytvoření týmů na základě seznamu jmen.
        /// </summary>
        [TestMethod]
        public void CreateTeams_CreatesTeamsFromNamesList()
        {
            // Příprava vstupních dat
            List<string> names = new List<string> { "Alice", "Bob", "Charlie", "David" };
            int numberOfTeams = 2;

            // Provádění testované operace
            string teamsAsString = teamsGenerator.CreateTeams(names, numberOfTeams);

            // Kontrola jestli výpis obsahuje týmy se jmény
            Assert.IsNotNull(teamsAsString);
            Assert.IsTrue(teamsAsString.Contains("Team 1"));
            Assert.IsTrue(teamsAsString.Contains("Team 2"));
            Assert.IsTrue(teamsAsString.Contains("Alice"));
            Assert.IsTrue(teamsAsString.Contains("Bob"));
            Assert.IsTrue(teamsAsString.Contains("Charlie"));
            Assert.IsTrue(teamsAsString.Contains("David"));
        }

        /// <summary>
        /// Testuje převod seznamu jmen týmu na textový řetězec.
        /// </summary>
        [TestMethod]
        public void TeamAsString_ConvertsTeamListToString()
        {
            // Příprava vstupních dat
            List<string> team = new List<string> { "Alice", "Bob", "Charlie" };

            // Provádění testované operace
            string teamAsString = teamsGenerator.TeamAsString(team);

            // Kontrola formátu výpisu listu týmu
            Assert.IsNotNull(teamAsString);
            Assert.AreEqual("Alice, Bob, Charlie", teamAsString);
        }
    }
}
