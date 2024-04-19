using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Třída pro generování náhodných písmen z abeced různých jazyků.
    /// </summary>
    public class LetterGenerator : RandomizerBase
    {
        /// <summary>
        /// Konstruktor třídy LetterGenerator.
        /// Načte abecedy z JSON souboru pomocí třídy JSONLoader.
        /// </summary>
        public LetterGenerator()
        {
            JSONLoader jsonLoader = new JSONLoader();
            alphabets = jsonLoader.LoadAlphabetsFromJSON();
        }

        private Dictionary<string, string> alphabets; // Slovník jazykových abeced

        /// <summary>
        /// Zobrazí uživateli nabídku dostupných jazyků a umožní mu vybrat.
        /// Následně zobrazí náhodné písmeno z vybrané abecedy.
        /// </summary>
        public override void Display()
        {

            // Zkontroluje, zda seznam abeced není prázdný a obsahuje alespoň jeden prvek
            if (alphabets != null && alphabets.Count > 0)
            {
                // Zobrazí dostupné jazyky uživateli
                Console.WriteLine("Available languages: ");
                for (int i = 0; i < alphabets.Count; i++)
                {
                    Console.WriteLine($"{(i + 1)}) {alphabets.ElementAt(i).Key}");
                }

                int intAnswer;
                while (true)
                {
                    Console.Write("Enter your choice or 'exit' to return to the menu: ");
                    string answer = Console.ReadLine();

                    if (Int32.TryParse(answer, out intAnswer))
                    {
                        if (intAnswer > 0 && intAnswer <= alphabets.Count)
                            break;
                        else
                            PrintError($"You entered a number outside the range of 1-{alphabets.Count}!");
                    }
                    else if (answer.Equals("exit"))
                    {
                        return;
                    }
                    else
                    {
                        PrintError("You did not enter a valid number!");
                    }
                }

                // Získá vybranou abecedu na základě uživatelovy volby
                string selectedAlphabet = alphabets.ElementAt(intAnswer - 1).Value;

                // Vygeneruje náhodné písmeno z dané abecedy
                char randomChar = GetChar(selectedAlphabet);
                Console.WriteLine($"Random letter: {randomChar}");
            }
        }

        /// <summary>
        /// Vygeneruje a vrátí náhodné písmeno z dané abecedy.
        /// </summary>
        /// <param name="chars">Sada znaků abecedy.</param>
        /// <returns>Náhodné písmeno z dané abecedy.</returns>
        private char GetChar(string chars)
        {
            return chars[random.Next(chars.Length)];
        }
    }
}
