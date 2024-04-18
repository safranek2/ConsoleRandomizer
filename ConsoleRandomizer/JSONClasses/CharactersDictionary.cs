using Newtonsoft.Json;

namespace ConsoleRandomizer.Randomizer.JSON_Classes
{
    /// <summary>
    /// Třída CharacterDictionary slouží k reprezentaci jednoho znaku pro generování hesel načtených z JSON souboru.
    /// </summary>
    public class CharactersDictionary
    {
        private string name; // Název znaků
        private string characters; // Znaky

        /// <summary>
        /// Vlastnost Name reprezentuje název znaků.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Vlastnost Characters reprezentuje samotné znaky.
        /// </summary>
        [JsonProperty("characters")]
        public string Characters
        {
            get { return characters; }
            set { characters = value; }
        }
    }
}
