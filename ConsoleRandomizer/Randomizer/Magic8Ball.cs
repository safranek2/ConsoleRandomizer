using System;
using System.Collections.Generic;

namespace ConsoleToolkit
{
    /// <summary>
    /// Třída Magic8Ball reprezentuje virtuální Magic 8 Ball, který poskytuje náhodné odpovědi na otázky.
    /// </summary>
    internal class Magic8Ball
    {
        /// <summary>
        /// Konstruktor třídy Magic8Ball. Načítá možné odpovědi z externího JSON souboru pomocí třídy JSONLoader.
        /// </summary>
        public Magic8Ball()
        {
            JSONLoader jsonLoader = new JSONLoader();
            answers = jsonLoader.LoadMagic8BallAnswersFromJSON();
        }

        private Random random = new Random(); // Instance generátoru náhodných čísel

        private List<string> answers; // Seznam možných odpovědí Magic 8 Ball

        /// <summary>
        /// Zobrazí náhodnou odpověď z listu možných odpovědí Magic 8 Ball.
        /// </summary>
        public void Display()
        {

            if (answers != null)
            {
                string randomAnswer = GenerateAnswer();
                Console.WriteLine("The Magic 8 Ball says: " + randomAnswer);
            }
        }

        /// <summary>
        /// Generuje náhodnou odpověď z listu možných odpovědí Magic 8 Ball.
        /// </summary>
        /// <returns>Náhodně vybraná odpověď z listu možných odpovědí.</returns>
        private string GenerateAnswer()
        {
            int index = random.Next(0, answers.Count);
            return answers[index];
        }
    }
}
