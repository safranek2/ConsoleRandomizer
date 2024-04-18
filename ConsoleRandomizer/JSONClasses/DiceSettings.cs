using Newtonsoft.Json;

namespace ConsoleRandomizer.Randomizer.JSON_Classes
{
    /// <summary>
    /// Třída pro reprezentaci nastavení pro házení kostek načtených z JSON souboru.
    /// </summary>
    public class DiceSettings
    {
        private int minDice; // Minimální počet kostek
        private int maxDice; // Maximální počet kostek
        private int minSides; // Minimální počet stran kostky
        private int maxSides; // Maximální počet stran kostky

        /// <summary>
        /// Vlastnost MinDice reprezentuje minimální počet kostek.
        /// </summary>
        [JsonProperty("minDice")]
        public int MinDice
        {
            get { return minDice; }
            set
            {
                minDice = value;
            }
        }

        /// <summary>
        /// Vlastnost MaxDice reprezentuje maximální počet kostek.
        /// </summary>
        [JsonProperty("maxDice")]
        public int MaxDice
        {
            get { return maxDice; }
            set
            {
                maxDice = value;
            }
        }

        /// <summary>
        /// Vlastnost MinSides reprezentuje minimální počet stran kostek.
        /// </summary>
        [JsonProperty("minSides")]
        public int MinSides
        {
            get { return minSides; }
            set
            {
                minSides = value;
            }
        }

        /// <summary>
        /// Vlastnost MaxSides reprezentuje maximální počet stran kostek.
        /// </summary>
        [JsonProperty("maxSides")]
        public int MaxSides
        {
            get { return maxSides; }
            set
            {

                maxSides = value;
            }
        }
    }
}
