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
        /// Zobrazí uživateli seznam dostupných jazyků a umožní mu vybrat jeden z nich. 
        /// Poté vygeneruje náhodný znak z vybrané abecedy tohoto jazyka a zobrazí ho.
        /// </summary>
        public override void Display()
        {
            // Kontrola, zda seznam jazyků není prázdný a obsahuje položky
            if (alphabets != null && alphabets.Count > 0)
            {
                // Výpis dostupných jazyků
                Console.WriteLine("Available languages: ");

                for (int i = 0; i < alphabets.Count; i++)
                {
                    Console.WriteLine($"{(i + 1)}) {alphabets.ElementAt(i).Key}");
                }

                int intAnswer;

                // Cyklus pro získání volby uživatele
                while (true)
                {
                    Console.Write("Enter your choice or 'exit' to return to the menu: ");

                    string answer = Console.ReadLine();

                    // Pokus o převedení vstupu na číslo
                    if (Int32.TryParse(answer, out intAnswer))
                    {
                        // Kontrola platnosti čísla v rozmezí dostupných jazyků
                        if (intAnswer > 0 && intAnswer <= alphabets.Count)
                        {
                            break;
                        }
                        else
                        {
                            PrintError($"You entered a number outside the range of 1-{alphabets.Count}!");
                        }
                    }
                    // Pokud uživatel zadá 'exit', metoda se ukončí
                    else if (answer.Equals("exit"))
                    {
                        return;
                    }
                    // Pokud uživatel nezadá platné číslo ani 'exit', vygeneruje se chybová hláška
                    else
                    {
                        PrintError("You did not enter a valid number!");
                    }
                }

                // Získání vybrané abecedy na základě uživatelova výběru
                string selectedAlphabet = alphabets.ElementAt(intAnswer - 1).Value;

                // Vygenerování náhodného znaku z vybrané abecedy a jeho zobrazení
                char randomChar = GetChar(selectedAlphabet);
                Console.WriteLine($"Random letter: {randomChar}");
            }
        }

        /// <summary>
        /// Generuje náhodně vybraný znak ze zadaného řetězce znaků.
        /// </summary>
        /// <param name="chars">Řetězec znaků, ze kterého se má vybírat.</param>
        /// <returns>Náhodně vybraný znak.</returns>
        public char GetChar(string chars)
        {
            // Generuje náhodně vybraný index v rozsahu délky řetězce znaků
            int randomIndex = random.Next(chars.Length);

            // Vybere a vrátí znak na vygenerovaném indexu
            return chars[randomIndex];
        }
    }
}
