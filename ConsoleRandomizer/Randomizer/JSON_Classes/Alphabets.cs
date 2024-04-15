using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleToolkit.Randomizer.JSON_Classes
{
    /// <summary>
    /// Třída pro reprezentaci nastavení abeced načtených z JSON souboru.
    /// </summary>
    internal class Alphabets
    {
        /// <summary>
        /// Slovník abeced.
        /// </summary>
        [JsonProperty("alphabets")]
        public Dictionary<string, string> AlphabetList { get; set; }
    }
}
