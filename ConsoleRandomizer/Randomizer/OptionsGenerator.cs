using System;
using System.Collections.Generic;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Třída pro generování a zobrazení náhodné možnosti z daného seznamu.
    /// </summary>
    public class OptionsGenerator
    {
        /// <summary>
        /// Konstruktor třídy OptionsGenerator.
        /// </summary>
        public OptionsGenerator()
        {
            // Prázdný konstruktor, žádná speciální inicializace není potřebná.
        }

        private readonly Random random = new Random(); // Instance třídy pro generování náhodných čísel.

        /// <summary>
        /// Zobrazí náhodnou možnost z daného seznamu.
        /// </summary>
        /// <param name="list">Seznam možností.</param>
        public void Display(List<string> list)
        {
            // Vrátí náhodnou možnost v seznamu a vypše ji.
            string randomItem = GenerateItem(list);
            Console.WriteLine($"It is: {randomItem}");
        }

        /// <summary>
        /// Generuje a vrátí náhodnou možnost z daného seznamu.
        /// </summary>
        /// <param name="list">Seznam možností.</param>
        /// <returns>Náhodně vybraná možnost ze seznamu.</returns>
        public string GenerateItem(List<string> list)
        {
            int randomIndex = random.Next(0, list.Count); // Generuje náhodný index v rozsahu seznamu možností.

            string randomItem = list[randomIndex]; // Vybere náhodnou možnost z daného seznamu.

            return randomItem; // Vrátí náhodně vybranou možnost ze seznamu.
        }
    }
}
