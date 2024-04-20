using System;
using System.Collections.Generic;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Třída Magic8Ball reprezentuje virtuální Magic 8 Ball, který poskytuje náhodné odpovědi na otázky.
    /// </summary>
    public class Magic8Ball : RandomizerBase
    {
        /// <summary>
        /// Konstruktor třídy Magic8Ball. Načítá možné odpovědi z externího JSON souboru pomocí třídy JSONLoader.
        /// </summary>
        public Magic8Ball()
        {
            JSONLoader jsonLoader = new JSONLoader();
            answers = jsonLoader.LoadMagic8BallAnswersFromJSON();
        }

        private List<string> answers; // Seznam možných odpovědí Magic 8 Ball

        /// <summary>
        /// Zobrazuje náhodnou odpověď od kouzelné koule.
        /// </summary>
        public override void Display()
        {
            if (answers != null)
            {
                string randomAnswer = GenerateAnswer(); // Vygeneruje náhodnou odpověď od kouzelné koule
                Console.WriteLine($"The Magic 8 Ball says: {randomAnswer}"); // Vypíše náhodnou odpověď od kouzelné koule
            }
        }

        /// <summary>
        /// Generuje náhodnou odpověď ze seznamu možných odpovědí.
        /// </summary>
        /// <returns>Náhodně vybraná odpověď ze seznamu.</returns>
        public string GenerateAnswer()
        {
            int index = random.Next(0, answers.Count); // Náhodně vybere index odpovědi ze seznamu
            return answers[index]; // Vrátí náhodně vybranou odpověď
        }

    }
}
