using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleToolkit.Randomizer.JSON_Classes
{
    /// <summary>
    /// Třída PasswordSettings slouží k reprezentaci možných znaků pro generování hesel načtených z JSON souboru.
    /// </summary>
    internal class PasswordSettings
    {
        private int minChars; // Minimální počet charakterů
        private int maxChars; // Maximální počet charakterů
        private List<CharactersDictionary> chars; // Seznam možných znaků

        /// <summary>
        /// Vlastnost MinChars reprezentuje minimální počet charakterů.
        /// </summary>
        [JsonProperty("minTeams")]
        public int MinChars
        {
            get { return minChars; }
            set
            {
                // Ošetření, aby hodnota neklesla pod 1
                if (value < 1)
                    minChars = 4;
                else
                    minChars = value;
            }
        }

        /// <summary>
        /// Vlastnost MaxChars reprezentuje maximální počet charakterů.
        /// </summary>
        [JsonProperty("maxTeams")]
        public int MaxChars
        {
            get { return maxChars; }
            set
            {
                // Ošetření, aby hodnota neklesla pod MinChars
                if (value < MinChars)
                {
                    if (MinChars < 35)
                        maxChars = 35;
                    else if (MinChars > 35)
                        maxChars = MinChars;
                }
                else
                    maxChars = value;
            }
        }


        /// <summary>
        /// Vlastnost Chars reprezentuje seznam možných znaků.
        /// </summary>
        [JsonProperty("Chars")]
        public List<CharactersDictionary> Chars
        {
            get { return chars; }
            set { chars = value; }
        }
    }
}
