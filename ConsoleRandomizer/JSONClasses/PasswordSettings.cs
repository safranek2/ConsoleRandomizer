using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleRandomizer.Randomizer.JSON_Classes
{
    /// <summary>
    /// Třída PasswordSettings slouží k reprezentaci možných znaků pro generování hesel načtených z JSON souboru.
    /// </summary>
    public class PasswordSettings
    {
        private int minChars; // Minimální počet charakterů
        private int maxChars; // Maximální počet charakterů
        private List<CharactersDictionary> chars; // Seznam možných znaků

        /// <summary>
        /// Získává nebo nastavuje minimální počet charakterů.
        /// </summary>
        [JsonProperty("minChars")]
        public int MinChars
        {
            get { return minChars; }
            set { minChars = value; }
        }

        /// <summary>
        /// Získává nebo nastavuje maximální počet charakterů.
        /// </summary>
        [JsonProperty("maxChars")]
        public int MaxChars
        {
            get { return maxChars; }
            set { maxChars = value; }
        }


        /// <summary>
        /// Získává nebo nastavuje seznam možných znaků.
        /// </summary>
        [JsonProperty("chars")]
        public List<CharactersDictionary> Chars
        {
            get { return chars; }
            set { chars = value; }
        }
    }
}
