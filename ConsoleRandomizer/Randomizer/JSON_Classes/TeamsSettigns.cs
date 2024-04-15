using Newtonsoft.Json;

namespace ConsoleToolkit.Randomizer.JSON_Classes
{
    internal class TeamsSettings
    {
        private int minTeams; // Minimální počet týmů
        private int maxTeams; // Maximální počet týmů

        /// <summary>
        /// Vlastnost MinTeams reprezentuje minimální počet týmů.
        /// </summary>
        [JsonProperty("minTeams")]
        public int MinTeams
        {
            get { return minTeams; }
            set
            {
                // Ošetření, aby hodnota neklesla pod 2
                if (value < 2)
                    minTeams = 2;
                else
                    minTeams = value;
            }
        }

        /// <summary>
        /// Vlastnost MaxTeams reprezentuje maximální počet týmů.
        /// </summary>
        [JsonProperty("maxTeams")]
        public int MaxTeams
        {
            get { return maxTeams; }
            set
            {
                // Ošetření, aby hodnota neklesla pod MinTeams
                if (value < MinTeams)
                {
                    if (MinTeams < 12)
                        maxTeams = 12;
                    else if (MinTeams > 12)
                        maxTeams = MinTeams;
                }
                else
                    maxTeams = value;
            }
        }
    }
}
