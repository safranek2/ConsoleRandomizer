using System;
using System.Collections.Generic;

namespace ConsoleToolkit
{
    /// <summary>
    /// Třída pro generování a manipulaci se seznamem jmen.
    /// </summary>
    internal class ListGenerator
    {
        /// <summary>
        /// Konstruktor třídy ListGenerator.
        /// </summary>
        public ListGenerator()
        {
            // Prázdný konstruktor, žádná speciální inicializace není potřebná.
        }

        private Random random = new Random(); // Instance pro generování náhodných čísel
        private ErrorController errorController = new ErrorController(); // Instance třídy pro správu chyb

        /// <summary>
        /// Zobrazí uživateli nabídku možností pro manipulaci se seznamem jmen a zpracovává jeho vstupy.
        /// </summary>
        public void Display()
        {
            List<string> list = new List<string>(); // Inicializuje nový prázdný seznam jmen
            bool enabled = false; // Indikuje, zda je seznam povolen nebo ne

            while (true)
            {
                // Zobrazí menu na základě toho, zda je seznam povolen nebo ne
                if (!enabled)
                {
                    Console.WriteLine("1) Add name\n0) Exit");
                }
                else
                {
                    Console.WriteLine("1) Add name\n2) Shuffle List\n3) Pick One!\n0) Exit");
                }

                Console.Write("Enter your choice: ");
                string answer = Console.ReadLine();

                if (Int32.TryParse(answer, out int intAnswer))
                {
                    if (intAnswer == 1)
                    {
                        AddName(list); // Přidá jméno do seznamu
                        if (!enabled && list.Count > 1)
                        {
                            enabled = true; // Pokud není seznam povolen a obsahuje více než jedno jméno, povolí se
                        }
                    }
                    else if (intAnswer == 2 && enabled)
                    {
                        ShuffleList(list); // Zamíchá seznam
                        break; // Ukončí cyklus a zobrazí výsledky
                    }
                    else if (intAnswer == 3 && enabled)
                    {
                        string name = list[random.Next(0, list.Count)]; // Vybere náhodné jméno ze seznamu
                        Console.WriteLine("Random name: " + name); // Zobrazí vybrané jméno
                        break; // Ukončí cyklus a zobrazí výsledky
                    }
                    else if (intAnswer == 0)
                    {
                        return; // Ukončí cyklus
                    }
                    else
                    {
                        errorController.PrintError("You entered an incorrect number!"); // Zobrazí chybovou hlášku pro nesprávné vstupy
                    }
                }
                else
                {
                    errorController.PrintError("You did not enter a number!"); // Zobrazí chybovou hlášku pro nečíselné vstupy
                }
            }
        }

        /// <summary>
        /// Přidá nové jméno do seznamu.
        /// </summary>
        /// <param name="list">Seznam jmen.</param>
        public void AddName(List<string> list)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            list.Add(name);
        }

        /// <summary>
        /// Zamíchá pořadí jmen v seznamu.
        /// </summary>
        /// <param name="list">Seznam jmen.</param>
        public void ShuffleList(List<string> list)
        {
            List<string> newList = new List<string>(); // Inicializuje nový prázdný seznam pro zamíchání

            while (list.Count > 0)
            {
                int index = random.Next(0, list.Count); // Vybere náhodný index ze seznamu
                newList.Add(list[index]); // Přidá jméno na náhodném indexu do nového seznamu
                list.RemoveAt(index); // Odebere jméno ze seznamu
            }

            WriteList(newList); // Zobrazí nově zamíchaný seznam
        }

        /// <summary>
        /// Zobrazí obsah seznamu na konzoli.
        /// </summary>
        /// <param name="list">Seznam jmen.</param>
        public void WriteList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write("Results: " + list[i]); // Pokud je to první prvek, vypíše bez čárky
                }
                else
                {
                    Console.Write(", " + list[i]); // Vypíše prvek s čárkou
                }
            }
            Console.WriteLine();
        }
    }
}
