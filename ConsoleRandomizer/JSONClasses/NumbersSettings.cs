using Newtonsoft.Json;

namespace ConsoleRandomizer.Randomizer.JSON_Classes
{
    /// <summary>
    /// Třída NumbersSettings slouží k reprezentaci minimálního a maximálního počtu čísel načtených z JSON souboru.
    /// </summary>
    public class NumbersSettings
    {
        private int minNumbers; // Minimální počet čísel
        private int maxNumbers; // Maximální počet čísel

        /// <summary>
        /// Získává nebo nastavuje minimální počet čísel.
        /// </summary>
        [JsonProperty("minNumbers")]
        public int MinNumbers
        {
            get { return minNumbers; }
            set { minNumbers = value; }
        }

        /// <summary>
        /// Získává nebo nastavuje maximální počet čísel.
        /// </summary>
        [JsonProperty("maxNumbers")]
        public int MaxNumbers
        {
            get { return maxNumbers; }
            set { maxNumbers = value; }
        }
    }
}
