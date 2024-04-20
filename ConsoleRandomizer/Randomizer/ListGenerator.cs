using System;
using System.Collections.Generic;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Třída pro generování a manipulaci se seznamem jmen.
    /// </summary>
    public class ListGenerator : RandomizerBase
    {
        /// <summary>
        /// Konstruktor třídy ListGenerator.
        /// </summary>
        public ListGenerator()
        {
            // Prázdný konstruktor, žádná speciální inicializace není potřebná.
        }

        /// <summary>
        /// Zobrazuje uživatelské rozhraní pro interakci s uživatelem a provádí operace v souladu s volbami.
        /// </summary>
        public override void Display()
        {
            List<string> list = new List<string>(); // Seznam pro ukládání jmen
            bool enabled = false; // Příznak, zda jsou povoleny pokročilé možnosti

            while (true)
            {
                // Výpis možností v závislosti na povolených funkcích
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

                // Zpracování uživatelovy volby
                if (Int32.TryParse(answer, out int intAnswer))
                {
                    if (intAnswer == 1)
                    {
                        // Volba pro přidání jména do seznamu
                        Console.Write("Name: ");

                        string name = Console.ReadLine();

                        AddName(list, name);

                        // Aktivace pokročilých funkcí po přidání druhého jména
                        if (!enabled && list.Count > 1)
                        {
                            enabled = true;
                        }
                    }
                    else if (intAnswer == 2 && enabled)
                    {
                        // Volba pro zamíchání seznamu jmen
                        List<string> results = ShuffleList(list);

                        string resultsAsString = ListAsString(results);

                        Console.WriteLine(resultsAsString);

                        break;
                    }
                    else if (intAnswer == 3 && enabled)
                    {
                        // Volba pro výběr náhodného jména ze seznamu
                        string name = list[random.Next(0, list.Count)];

                        Console.WriteLine($"Random name: {name}");

                        break;
                    }
                    else if (intAnswer == 0)
                    {
                        // Vrácení do hlavního menu
                        return;
                    }
                    else
                    {
                        // Pokud uživatel zadal neplatné číslo
                        PrintError("You entered an incorrect number!");
                    }
                }
                else
                {
                    // Pokud uživatel nezadal číslo
                    PrintError("You did not enter a number!");
                }
            }
        }

        /// <summary>
        /// Přidá zadané jméno do zadaného seznamu jmen.
        /// </summary>
        /// <param name="list">Seznam, do kterého má být přidáno jméno.</param>
        /// <param name="name">Jméno, které má být přidáno do seznamu.</param>
        public void AddName(List<string> list, string name)
        {
            list.Add(name);
        }


        /// <summary>
        /// Zamíchá položky v zadaném seznamu náhodným způsobem a vrátí nový seznam se zamíchanými položkami.
        /// </summary>
        /// <param name="list">Seznam položek, které mají být zamíchány.</param>
        /// <returns>Nový seznam s položkami ze vstupního seznamu, ale v náhodném pořadí.</returns>
        public List<string> ShuffleList(List<string> list)
        {
            List<string> newList = new List<string>();

            while (list.Count > 0)
            {
                // Vybere náhodný index položky ze seznamu
                int index = random.Next(0, list.Count);

                // Přidá vybranou položku na konec nového seznamu
                newList.Add(list[index]);

                // Odstraní vybranou položku ze vstupního seznamu
                list.RemoveAt(index);
            }

            return newList;
        }

        /// <summary>
        /// Vytváří textový řetězec obsahující všechny položky ze zadaného seznamu.
        /// </summary>
        /// <param name="list">Seznam položek, ze kterého má být vytvořen textový řetězec.</param>
        /// <returns>Textový řetězec obsahující všechny položky ze zadaného seznamu oddělené čárkami.</returns>
        public string ListAsString(List<string> list)
        {
            string result = "";
            for (int i = 0; i < list.Count; i++)
            {
                // První položka v seznamu
                if (i == 0)
                {
                    result = $"Results: {list[i]}";
                }
                // Ostatní položky v seznamu
                else
                {
                    result += $", {list[i]}";
                }
            }
            return result;
        }
    }
}
