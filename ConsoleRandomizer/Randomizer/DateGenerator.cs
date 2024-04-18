using System;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Třída pro generování náhodných dat mezi dvěma zadanými daty.
    /// </summary>
    public class DateGenerator
    {
        /// <summary>
        /// Konstruktor třídy DateGenerator.
        /// </summary>
        public DateGenerator()
        {
            // Prázdný konstruktor, žádná speciální inicializace není potřebná.
        }

        private Random random = new Random(); // Instance třídy pro generování náhodných čísel
        private ErrorController errorController = new ErrorController(); // Instance třídy pro správu chyb

        /// <summary>
        /// Zobrazí menu generátoru dat a zpracuje uživatelský vstup.
        /// </summary>
        public void Display()
        {
            DateTime firstDate;
            DateTime lastDate;

            // Zobrazí uživateli výzvu k zadání prvního data
            while (true)
            {
                Console.Write("Enter the first date in d.m.yyyy format or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                if (answer.Equals("exit"))
                {
                    return;
                }

                // Pokusí se analyzovat uživatelský vstup jako DateTime
                if (DateTime.TryParse(answer, out firstDate))
                {
                    break;
                }
                else
                {
                    errorController.PrintError("You have not entered a valid date!");
                }
            }

            // Zobrazí uživateli výzvu k zadání posledního data
            while (true)
            {
                Console.Write("Enter the last date in d.m.yyyy format or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                if (answer.Equals("exit"))
                {
                    return;
                }

                // Pokusí se analyzovat uživatelský vstup jako DateTime
                if (DateTime.TryParse(answer, out lastDate))
                {
                    // Kontroluje, zda je poslední datum pozdější než první datum
                    if (firstDate >= lastDate)
                    {
                        errorController.PrintError("The last date must be later than the first date!");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    errorController.PrintError("You have not entered a valid date!");
                }
            }

            // Generuje náhodné datum mezi zadanými daty
            GenerateDate(firstDate, lastDate);
        }

        /// <summary>
        /// Generuje náhodné datum mezi zadanými daty a vypíše je.
        /// </summary>
        /// <param name="firstDate">První datum v rozsahu.</param>
        /// <param name="lastDate">Poslední datum v rozsahu.</param>
        public void GenerateDate(DateTime firstDate, DateTime lastDate)
        {
            // Vypočítá počet dnů mezi dvěma daty
            TimeSpan timeSpan = lastDate - firstDate;
            int daysBetween = (int)timeSpan.TotalDays;

            // Vygeneruje náhodný počet dnů mezi dvěma daty a přidá ho k prvnímu datu
            DateTime randomDate = firstDate.AddDays(random.Next(daysBetween + 1));

            // Vypíše náhodně vygenerované datum ve formátu "d.M.yyyy"
            Console.WriteLine($"Random date: {randomDate.ToString("d.M.yyyy")}");
        }
    }
}
