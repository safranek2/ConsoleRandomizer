using Newtonsoft.Json;

namespace ConsoleToolkit.Randomizer.JSON_Classes
{
    /// <summary>
    /// Třída pro reprezentaci nastavení pro házení kostek načtených z JSON souboru.
    /// </summary>
    internal class DiceSettings
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
                // Ošetření, aby hodnota neklesla pod 1
                if (value < 1)
                    minDice = 1;
                else
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
                // Ošetření, aby hodnota neklesla pod MinDice
                if (value < minDice)
                {
                    if (minDice < 10)
                        maxDice = 10;
                    else if (minDice > 10)
                        maxDice = minDice;
                }
                else
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
                // Ošetření, aby hodnota neklesla pod 3
                if (value < 3)
                    minSides = 3;
                else
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
                // Ošetření, aby hodnota neklesla pod MinSides
                if (value < minSides)
                {
                    if (minSides < 100)
                        maxSides = 100;
                    else if (minSides > 100)
                        maxSides = minSides;
                }
                else
                    maxSides = value;
            }
        }
    }
}
