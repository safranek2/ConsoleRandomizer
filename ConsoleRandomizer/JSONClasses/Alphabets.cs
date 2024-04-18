using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleRandomizer.Randomizer.JSON_Classes
{
    /// <summary>
    /// Třída reprezentující nastavení abeced načtené z JSON souboru.
    /// </summary>
    public class Alphabets
    {
        /// <summary>
        /// Slovník abeced.
        /// Klíč je název abecedy, hodnota je samotná abeceda ve formě řetězce charakterů.
        /// </summary>
        [JsonProperty("alphabets")]
        public Dictionary<string, string> AlphabetList { get; set; }
    }
}
