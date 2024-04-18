using System;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Třída TimeGenerator umožňuje generovat náhodný časový údaj v zadaném rozmezí.
    /// </summary>
    public class TimeGenerator
    {
        private Random random = new Random(); // Instance generátoru náhodných čísel.

        private ErrorController errorController = new ErrorController(); // Instance třídy pro zpracování chyb.

        /// <summary>
        /// Konstruktor třídy TimeGenerator.
        /// </summary>
        public TimeGenerator()
        {
            // Prázdný konstruktor, žádná speciální inicializace není potřebná.
        }

        /// <summary>
        /// Zobrazí menu pro zadání prvního a posledního časového údaje a zpracovává vstup uživatele.
        /// </summary>
        public void Display()
        {
            DateTime firstTime; // Proměnná pro první časový údaj.
            DateTime lastTime; // Proměnná pro poslední časový údaj.

            // Cyklus pro zadání prvního časového údaje.
            while (true)
            {
                Console.Write("Enter the first time in H:mm format or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                // Zkontroluje, zda je zadaný vstup platným časem.
                if (DateTime.TryParseExact(answer, "H:mm", null, System.Globalization.DateTimeStyles.None, out firstTime))
                {
                    break;
                }
                else if (answer.Equals("exit"))
                {
                    return;
                }
                else
                {
                    errorController.PrintError("You have not entered a time or entered an invalid time!");
                }
            }

            // Cyklus pro zadání posledního časového údaje.
            while (true)
            {
                Console.Write("Enter the last time in H:mm format or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                // Zkontroluje, zda je zadaný vstup platným časem.
                if (DateTime.TryParseExact(answer, "H:mm", null, System.Globalization.DateTimeStyles.None, out lastTime))
                {
                    // Kontroluje, zda je poslední čas pozdější než první čas.
                    if (firstTime >= lastTime)
                    {
                        errorController.PrintError("The last time must be later than the first time!");
                    }
                    else
                    {
                        break;
                    }
                }
                else if (answer.Equals("exit"))
                {
                    return;
                }
                else
                {
                    errorController.PrintError("You have not entered a time or entered an invalid time!");
                }
            }

            // Generuje náhodný časový údaj v zadaném rozmezí.
            GenerateTime(firstTime, lastTime);
        }

        /// <summary>
        /// Generuje náhodný časový údaj mezi prvním a posledním časem a vypisuje jej na konzoli.
        /// </summary>
        /// <param name="firstTime">První časový údaj.</param>
        /// <param name="lastTime">Poslední časový údaj.</param>
        public void GenerateTime(DateTime firstTime, DateTime lastTime)
        {
            // Vypočítá počet minut mezi dvěma daty.
            TimeSpan timeSpan = lastTime - firstTime;
            int minutes = (int)timeSpan.TotalMinutes;

            // Vygeneruje náhodný čas v zadaném rozmezí.
            DateTime randomTime = firstTime.AddMinutes(random.Next(minutes + 1));

            // Vypíše vygenerovaný čas ve specifikovaném formátu.
            Console.WriteLine($"Random time: {randomTime.ToString("H:mm")}");
        }
    }
}
