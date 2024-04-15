using System;
using System.Collections.Generic;

namespace ConsoleToolkit
{
    /// <summary>
    /// Třída pro generování a zobrazení náhodné možnosti z daného seznamu.
    /// </summary>
    internal class OptionsGenerator
    {
        private Random random = new Random();

        /// <summary>
        /// Konstruktor třídy OptionsGenerator.
        /// </summary>
        public OptionsGenerator()
        {
            // Prázdný konstruktor, žádná speciální inicializace není potřebná.
        }

        /// <summary>
        /// Zobrazí náhodnou možnost z daného seznamu.
        /// </summary>
        /// <param name="list">Seznam možností.</param>
        public void Display(List<string> list)
        {
            // Generuje náhodný index v rozsahu seznamu možností.
            int randomIndex = random.Next(0, list.Count);

            // Zobrazí náhodnou možnost v konzoli.
            Console.WriteLine("It is: " + list[randomIndex]);
        }
    }
}
