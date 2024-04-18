using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleRandomizer.Randomizer.JSON_Classes
{
    /// <summary>
    /// Třída pro reprezentaci odpovědí Magic 8 Ball načtených z JSON souboru.
    /// </summary>
    public class Magic8BallAnswers
    {
        /// <summary>
        /// Seznam možných odpovědí Magic 8 Ball.
        /// </summary>
        [JsonProperty("answers")]
        public List<string> Answers { get; set; }
    }
}
