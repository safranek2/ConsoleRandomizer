using ConsoleRandomizer.Randomizer.JSON_Classes;
using System;
using System.Collections.Generic;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Třída <c>TeamsGenerator</c> slouží k generování týmů na základě uživatelských vstupů.
    /// </summary>
    public class TeamsGenerator : RandomizerBase
    {
        /// <summary>
        /// Konstruktor třídy <c>TeamsGenerator</c> inicializuje instanci generátoru náhodných čísel a načte nastavení týmů z JSON souboru.
        /// </summary>
        public TeamsGenerator()
        {
            JSONLoader jsonLoader = new JSONLoader(); // Instance třídy pro načítání JSON souborů.
            TeamsSettings teamsSettings = jsonLoader.LoadTeamsSettingsFromJSON(); // Načtení nastavení týmů z JSON souboru.

            minTeams = teamsSettings.MinTeams; // Nastavení minimálního počtu týmů.
            maxTeams = teamsSettings.MaxTeams; // Nastavení maximálního počtu týmů.
        }

        private int minTeams; // Minimální počet týmů.
        private int maxTeams; // Maximální počet týmů.

        /// <summary>
        /// Zobrazuje uživatelské rozhraní pro vytvoření týmů na základě zadaných jmen a zpracovává uživatelský vstup.
        /// </summary>
        public override void Display()
        {
            List<string> names = new List<string>(); // Inicializace prázdného seznamu pro ukládání jmen hráčů
            bool enabled = false; // Nastavení počáteční hodnoty proměnné označující povolení možnosti vytvoření týmů

            // Hlavní smyčka pro zobrazování menu a zpracování vstupu
            while (true)
            {
                // Zobrazení hlavního menu s možností přidání jména a vytvoření týmů (pokud je povoleno)
                if (!enabled)
                {
                    Console.WriteLine("1) Add name\n0) Exit");
                }
                else
                {
                    Console.WriteLine("1) Add name\n2) Create teams\n0) Exit");
                }

                Console.Write("Enter your choice: ");
                string answer = Console.ReadLine();

                // Zpracování vstupu uživatele
                if (Int32.TryParse(answer, out int intAnswer))
                {
                    if (intAnswer == 1)
                    {
                        // Přidání jména do seznamu jmen
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        AddName(names, name);

                        // Aktualizace stavu - pokud je dostatek jmen, povolí se volba pro vytvoření týmů
                        if (!enabled && names.Count > 1)
                        {
                            enabled = true;
                        }
                    }
                    else if (intAnswer == 2 && enabled)
                    {
                        // Pokud je volba povolena a uživatel vybere možnost vytvoření týmů, ukončí se smyčka a pokračuje se k vytváření týmů
                        break;
                    }
                    else if (intAnswer == 0)
                    {
                        // Pokud uživatel zvolí ukončení programu, metoda se vrátí a program skončí
                        return;
                    }
                    else
                    {
                        // Pokud uživatel zvolí neplatnou volbu, vypíše se chybová zpráva
                        PrintError("You entered an invalid number!");
                    }
                }
                else
                {
                    // Pokud uživatel nezadá číselnou volbu, vypíše se chybová zpráva
                    PrintError("You didn't enter a number!");
                }
            }

            // Po výběru možnosti vytvořit týmy se získá počet požadovaných týmů od uživatele
            int count;

            while (true)
            {
                Console.Write($"Enter the number of teams from {minTeams} to {maxTeams} or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                if (Int32.TryParse(answer, out count))
                {
                    // Kontrola platnosti zadaného počtu týmů
                    if (count >= names.Count)
                    {
                        PrintError("The number of teams must be less than or equal to the number of names!");
                    }
                    else if (count >= minTeams && count <= maxTeams)
                    {
                        // Pokud je zadaný počet týmů platný, ukončí se smyčka a pokračuje se k vytváření týmů
                        break;
                    }
                    else
                    {
                        // Pokud je zadaný počet týmů mimo povolený rozsah, vypíše se chybová zpráva
                        PrintError($"You entered a number outside the range of {minTeams}-{maxTeams}!");
                    }
                }
                else if (answer.Equals("exit"))
                {
                    // Pokud uživatel zvolí návrat do menu, metoda se vrátí a program pokračuje z hlavního menu
                    return;
                }
                else
                {
                    // Pokud uživatel nezadá číselnou hodnotu, vypíše se chybová zpráva
                    PrintError("You didn't enter a number!");
                }
            }

            // Vytvoření týmů na základě zadaných jmen a počtu týmů
            string teamsAsString = CreateTeams(names, count);

            // Vypsání vytvořených týmů
            Console.WriteLine(teamsAsString);
        }

        /// <summary>
        /// Přidá jméno do seznamu jmen pro týmy.
        /// </summary>
        /// <param name="names">Seznam jmen pro týmy.</param>
        /// <param name="name">Jméno, které má být přidáno do seznamu.</param>
        public void AddName(List<string> names, string name)
        {
            names.Add(name);
        }

        /// <summary>
        /// Metoda pro vytvoření týmů ze seznamu jmen.
        /// </summary>
        /// <param name="names">Seznam jmen hráčů k rozdělení do týmů.</param>
        /// <param name="count">Počet týmů, které mají být vytvořeny.</param>
        /// <returns>Textový řetězec obsahující informace o vytvořených týmech.</returns>
        public string CreateTeams(List<string> names, int count)
        {
            string result = "";

            // Výpočet počtu hráčů v každém týmu
            int numberOfNamesInTeam = (int)Math.Ceiling((double)names.Count / count);

            // Počet zbývajících hráčů k přiřazení do týmů
            int remainingPlayers = names.Count;

            // Procházení počtu týmů
            for (int i = 1; i <= count; i++)
            {
                // Určení počtu hráčů v daném týmu
                int playersInTeam = Math.Min(numberOfNamesInTeam, remainingPlayers);

                // Inicializace seznamu pro uchování jmen týmu
                List<string> team = new List<string>();

                // Přiřazení hráčů do týmu
                for (int x = 0; x < playersInTeam; x++)
                {
                    // Získání náhodného indexu ze seznamu jmen
                    if (names.Count > 0)
                    {
                        int index = random.Next(0, names.Count);

                        // Přidání hráče do týmu
                        team.Add(names[index]);
                        names.RemoveAt(index);
                    }
                    else
                    {
                        break;
                    }
                }

                // Aktualizace zbývajícího počtu hráčů k přiřazení do týmů
                remainingPlayers -= playersInTeam;

                // Převod seznamu jmen týmu na textový řetězec
                string teamAsString = TeamAsString(team);

                // Přidání informací o týmu do výsledného textového řetězce
                result += $"Team {i}: {teamAsString}";

                // Pokud již nejsou žádná další jména k přiřazení, ukončení cyklu
                if (names.Count == 0)
                {
                    break;
                }
            }

            // Vracení výsledného textového řetězce obsahujícího informace o vytvořených týmech
            return result;
        }

        /// <summary>
        /// Metoda převede seznam jmen týmu na řetězec, kde jednotlivá jména jsou oddělena čárkami.
        /// </summary>
        /// <param name="team">Seznam obsahující jména členů týmu.</param>
        /// <returns>Řetězec obsahující jména členů týmu, oddělená čárkami.</returns>
        public string TeamAsString(List<string> team)
        {
            // Inicializace proměnné pro uchování výsledného řetězce.
            string result = "";

            // Procházení všech prvků seznamu.
            for (int i = 0; i < team.Count; i++)
            {
                // Pokud je to první prvek seznamu, není přidána čárka před jménem.
                if (i == 0)
                {
                    result += $"{team[i]}";
                }
                // Pokud není první prvek seznamu, přidá se čárka před jménem.
                else
                {
                    result += $", {team[i]}";
                }
            }

            // Návrat výsledného řetězce obsahujícího jména členů týmu.
            return result;
        }
    }
}
