using Newtonsoft.Json;

namespace ConsoleToolkit.Randomizer.JSON_Classes
{
    /// <summary>
    /// Třída NumbersSettings slouží k reprezentaci maximálního počtu čísel načtených z JSON souboru.
    /// </summary>
    internal class NumbersSettings
    {
        private int maxNumbers; // Maximální počet čísel

        /// <summary>
        /// Vlastnost MaxNumbers reprezentuje maximální počet čísel načtených z JSON souboru.
        /// </summary>
        [JsonProperty("maxNumbers")]
        public int MaxNumbers
        {
            get { return maxNumbers; }
            set
            {
                // Ošetření, aby hodnota neklesla pod 100
                if (value < 1)
                    maxNumbers = 100;
                else
                    maxNumbers = value;
            }
        }
    }
}
