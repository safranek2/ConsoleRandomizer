using System;
using System.Collections.Generic;

namespace ConsoleToolkit
{
    /// <summary>
    /// Třída pro generování náhodných zemí na základě načtených dat ze souboru JSON.
    /// </summary>
    internal class CountryGenerator
    {
        /// <summary>
        /// Konstruktor třídy CountryGenerator, který inicializuje seznam zemí načtených ze souboru JSON.
        /// </summary>
        public CountryGenerator()
        {
            JSONLoader jsonLoader = new JSONLoader();
            countries = jsonLoader.LoadCountriesFromJSON(); // Načte seznam zemí ze souboru JSON pomocí instance jsonLoader
        }

        private Random random = new Random(); // Instance třídy pro generování náhodných čísel

        private List<string> countries; // Seznam zemí načtených ze souboru JSON

        /// <summary>
        /// Metoda pro zobrazení náhodně vybrané země.
        /// </summary>
        public void Display()
        {
            // Zkontroluje, zda seznam zemí není prázdný a obsahuje alespoň jeden prvek
            if (countries != null && countries.Count > 0)
            {
                // Získá náhodně vybranou zemi
                string randomCountry = GetRandomCountry();

                // Vypíše název náhodně vybrané země
                Console.WriteLine("Random country: " + randomCountry);
            }
        }

        /// <summary>
        /// Metoda pro generování náhodně vybrané země z seznamu zemí.
        /// </summary>
        /// <returns>Název náhodně vybrané země.</returns>
        private string GetRandomCountry()
        {
            // Generuje náhodný index v rozsahu délky seznamu zemí
            int randomIndex = random.Next(countries.Count);

            // Získá název země na náhodném indexu
            string randomCountry = countries[randomIndex];

            return randomCountry;
        }
    }
}
