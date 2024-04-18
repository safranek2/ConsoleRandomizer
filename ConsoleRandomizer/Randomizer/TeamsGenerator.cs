using ConsoleRandomizer.Randomizer.JSON_Classes;
using System;
using System.Collections.Generic;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Třída <c>TeamsGenerator</c> slouží k generování týmů na základě uživatelských vstupů.
    /// </summary>
    public class TeamsGenerator
    {
        private Random random = new Random(); // Instance generátoru náhodných čísel.
        private ErrorController errorController = new ErrorController(); // Instance řadiče chyb.

        private int minTeams; // Minimální počet týmů.
        private int maxTeams; // Maximální počet týmů.

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

        /// <summary>
        /// Zobrazí menu pro generování týmů a zpracovává uživatelské vstupy.
        /// </summary>
        public void Display()
        {
            List<string> names = new List<string>(); // Seznam jmen pro týmy.
            bool enabled = false; // Příznak, zda je možné vytvářet týmy.

            while (true)
            {
                // Zobrazení menu pro přidání jmen a vytvoření týmů.
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

                if (Int32.TryParse(answer, out int intAnswer))
                {
                    // Zpracování uživatelské volby.
                    if (intAnswer == 1)
                    {
                        AddName(names); // Přidání jména do seznamu jmen.
                        if (!enabled && names.Count > 1)
                        {
                            enabled = true; // Aktivace možnosti vytvářet týmy.
                        }
                    }
                    else if (intAnswer == 2 && enabled)
                    {
                        break; // Vytvoření týmů na základě zadaných jmen.
                    }
                    else if (intAnswer == 0)
                    {
                        return; // Ukončení programu.
                    }
                    else
                    {
                        errorController.PrintError("You entered an invalid number!"); // Vypsání chybového hlášení.
                    }
                }
                else
                {
                    errorController.PrintError("You didn't enter a number!"); // Vypsání chybového hlášení.
                }
            }

            int count;

            while (true)
            {
                Console.Write($"Enter the number of teams from {minTeams} to {maxTeams} or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                if (Int32.TryParse(answer, out count))
                {
                    // Kontrola platnosti zadaného počtu týmů.
                    if (count >= names.Count)
                    {
                        errorController.PrintError("The number of teams must be less than or equal to the number of names!");
                    }
                    else if (count >= minTeams && count <= maxTeams)
                    {
                        break; // Pokračování ve vytváření týmů.
                    }
                    else
                    {
                        errorController.PrintError($"You entered a number outside the range of {minTeams}-{maxTeams}!");
                    }
                }
                else if (answer.Equals("exit"))
                {
                    return; // Návrat do hlavního menu.
                }
                else
                {
                    errorController.PrintError("You didn't enter a number!"); // Vypsání chybového hlášení.
                }
            }

            CreateTeams(names, count); // Vytvoření týmů.
        }

        /// <summary>
        /// Přidá jméno do seznamu jmen pro týmy.
        /// </summary>
        /// <param name="names">Seznam jmen pro týmy.</param>
        private void AddName(List<string> names)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            names.Add(name);
        }

        /// <summary>
        /// Vytvoří týmy na základě zadaných jmen. Pokud je počet jmen menší než počet týmů, každý tým bude obsahovat pouze jednoho hráče.
        /// Pokud je počet jmen větší než počet týmů, jsou týmy vytvořeny férově tak, aby byla zachována rovnoměrná distribuce hráčů.
        /// </summary>
        /// <param name="names">Seznam jmen, ze kterých mají být vytvořeny týmy.</param>
        /// <param name="count">Počet týmů k vytvoření.</param>
        private void CreateTeams(List<string> names, int count)
        {
            // Vypočítá počet hráčů v jednom týmu, zaokrouhlený nahoru.
            int numberOfNamesInTeam = (int)Math.Ceiling((double)names.Count / count);

            // Počet zbývajících hráčů, které ještě není přiřazeno do týmů.
            int remainingPlayers = names.Count;

            // Projde všechny týmy a přiřadí jim hráče z listu jmen.
            for (int i = 1; i <= count; i++)
            {
                // Určí počet hráčů v aktuálním týmu. Poslední tým může mít méně hráčů, pokud nebylo přesně rozděleno.
                int playersInTeam = Math.Min(numberOfNamesInTeam, remainingPlayers);

                // Inicializuje nový tým pro aktuální hráče.
                List<string> team = new List<string>();

                // Přiřadí hráče do týmu, dokud nejsou naplněny všechny pozice v týmu nebo není vyčerpán seznam jmen.
                for (int x = 0; x < playersInTeam; x++)
                {
                    // Zajistí, že jsou k dispozici další hráči v seznamu jmen.
                    if (names.Count > 0)
                    {
                        // Náhodně vybere hráče ze seznamu jmen.
                        int index = random.Next(0, names.Count);
                        // Přidá a odstraní vybraného hráče.
                        team.Add(names[index]);
                        names.RemoveAt(index);
                    }
                    else
                    {
                        // Pokud nejsou k dispozici žádní další hráči, přeruší cyklus.
                        break;
                    }
                }

                // Aktualizuje počet zbývajících hráčů.
                remainingPlayers -= playersInTeam;

                // Vypíše jména hráčů v aktuálním týmu.
                Console.Write($"Team {i}: ");
                WriteTeam(team);

                // Pokud již nejsou k dispozici žádní další hráči, přeruší tvorbu dalších týmů.
                if (names.Count == 0)
                {
                    break;
                }
            }
        }


        /// <summary>
        /// Vypíše jména členů týmu oddělená čárkou.
        /// </summary>
        /// <param name="team">Seznam jmen členů týmu.</param>
        private void WriteTeam(List<string> team)
        {
            for (int i = 0; i < team.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(team[i]);
                }
                else
                {
                    Console.Write(", " + team[i]);
                }
            }
            Console.WriteLine();
        }
    }
}
