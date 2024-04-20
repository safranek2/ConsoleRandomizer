using System;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Třída pro generování náhodných dat mezi dvěma zadanými daty.
    /// </summary>
    public class DateGenerator : RandomizerBase
    {
        /// <summary>
        /// Konstruktor třídy DateGenerator.
        /// </summary>
        public DateGenerator()
        {
            // Prázdný konstruktor, žádná speciální inicializace není potřebná.
        }

        /// <summary>
        /// Zobrazuje uživatelské rozhraní pro generování náhodného data mezi zadanými daty a zpracovává uživatelský vstup.
        /// </summary>
        public override void Display()
        {
            DateTime firstDate; // Počáteční datum
            DateTime lastDate; // Koncové datum

            while (true)
            {
                // Vyzve uživatele k zadání počátečního data
                Console.Write("Enter the first date in d.m.yyyy format or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                // Pokud uživatel zvolil ukončení, metoda se vrátí zpět do menu
                if (answer.Equals("exit"))
                {
                    return;
                }

                // Pokusí se načíst počáteční datum z uživatelského vstupu
                if (DateTime.TryParse(answer, out firstDate))
                {
                    break; // Pokud je datum platné, ukončí smyčku
                }
                else
                {
                    PrintError("You have not entered a valid date!"); // Pokud je datum neplatné, vypíše chybovou zprávu
                }
            }

            while (true)
            {
                // Vyzve uživatele k zadání koncového data
                Console.Write("Enter the last date in d.m.yyyy format or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                // Pokud uživatel zvolil ukončení, metoda se vrátí zpět do menu
                if (answer.Equals("exit"))
                {
                    return;
                }

                // Pokusí se načíst koncové datum z uživatelského vstupu
                if (DateTime.TryParse(answer, out lastDate))
                {
                    // Kontroluje, zda je koncové datum pozdější než počáteční datum
                    if (firstDate >= lastDate)
                    {
                        PrintError("The last date must be later than the first date!");
                    }
                    else
                    {
                        break; // Pokud je datum platné a je pozdější než počáteční datum, ukončí smyčku
                    }
                }
                else
                {
                    PrintError("You have not entered a valid date!"); // Pokud je datum neplatné, vypíše chybovou zprávu
                }
            }

            // Vygeneruje náhodné datum mezi zadanými daty
            DateTime randomDate = GenerateDate(firstDate, lastDate);

            // Vypíše náhodně vygenerované datum
            Console.WriteLine($"Random date: {randomDate.ToString("d.M.yyyy")}");
        }

        /// <summary>
        /// Generuje náhodné datum mezi zadanými daty (včetně).
        /// </summary>
        /// <param name="firstDate">Počáteční datum.</param>
        /// <param name="lastDate">Koncové datum.</param>
        /// <returns>Náhodné datum v rozmezí mezi počátečním a koncovým datem.</returns>
        public DateTime GenerateDate(DateTime firstDate, DateTime lastDate)
        {
            // Vypočítá rozdíl mezi počátečním a koncovým datem
            TimeSpan timeSpan = lastDate - firstDate;
            int daysBetween = (int)timeSpan.TotalDays;

            // Vygeneruje náhodný počet dnů mezi oběma daty a přičte tento počet dnů k počátečnímu datu
            DateTime randomDate = firstDate.AddDays(random.Next(daysBetween + 1));

            return randomDate; // Vrátí vygenerované náhodné datum
        }
    }
}
