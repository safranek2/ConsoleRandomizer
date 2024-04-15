using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleToolkit.Randomizer.JSON_Classes
{
    /// <summary>
    /// Třída pro reprezentaci seznamu zemí načtených z JSON souboru.
    /// </summary>
    internal class Countries
    {
        /// <summary>
        /// Seznam zemí načtených z JSON souboru.
        /// </summary>
        [JsonProperty("countries")]
        public List<string> CountryList { get; set; }
    }
}