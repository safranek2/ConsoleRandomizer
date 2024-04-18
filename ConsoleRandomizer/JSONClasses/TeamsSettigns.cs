using Newtonsoft.Json;

namespace ConsoleRandomizer.Randomizer.JSON_Classes
{
    /// <summary>
    /// Třída TeamsSettings reprezentuje nastavení počtu týmů načtených z JSON souboru.
    /// </summary>
    public class TeamsSettings
    {
        private int minTeams; // Minimální počet týmů
        private int maxTeams; // Maximální počet týmů

        /// <summary>
        /// Získává nebo nastavuje minimální počet týmů.
        /// </summary>
        [JsonProperty("minTeams")]
        public int MinTeams
        {
            get { return minTeams; }
            set { minTeams = value; }
        }

        /// <summary>
        /// Získává nebo nastavuje maximální počet týmů.
        /// </summary>
        [JsonProperty("maxTeams")]
        public int MaxTeams
        {
            get { return maxTeams; }
            set { maxTeams = value; }
        }
    }
}
