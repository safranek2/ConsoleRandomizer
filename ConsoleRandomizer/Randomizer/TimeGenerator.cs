using System;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Třída TimeGenerator umožňuje generovat náhodný časový údaj v zadaném rozmezí.
    /// </summary>
    public class TimeGenerator : RandomizerBase
    {
        /// <summary>
        /// Konstruktor třídy TimeGenerator.
        /// </summary>
        public TimeGenerator()
        {
            // Prázdný konstruktor, žádná speciální inicializace není potřebná.
        }

        /// <summary>
        /// Zobrazuje uživatelské rozhraní pro generování náhodného časového údaje v zadaném rozsahu a zpracovává uživatelský vstup.
        /// </summary>
        public override void Display()
        {
            DateTime firstTime; // První časový údaj, začátek rozsahu generování.
            DateTime lastTime; // Poslední časový údaj, konec rozsahu generování.

            // Získání prvního časového údaje od uživatele
            while (true)
            {
                Console.Write("Enter the first time in H:mm format or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                // Pokus o převod zadaného času na DateTime
                if (DateTime.TryParseExact(answer, "H:mm", null, System.Globalization.DateTimeStyles.None, out firstTime))
                {
                    break;
                }
                // Pokud uživatel chce vrátit se zpět do menu
                else if (answer.Equals("exit"))
                {
                    return;
                }
                // Pokud uživatel zadal neplatný čas
                else
                {
                    PrintError("You have not entered a time or entered an invalid time!");
                }
            }

            // Získání posledního časového údaje od uživatele
            while (true)
            {
                Console.Write("Enter the last time in H:mm format or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();
                // Pokus o převod zadaného času na DateTime
                if (DateTime.TryParseExact(answer, "H:mm", null, System.Globalization.DateTimeStyles.None, out lastTime))
                {
                    // Kontrola, zda je poslední čas později než první čas
                    if (firstTime >= lastTime)
                    {
                        PrintError("The last time must be later than the first time!");
                    }
                    else
                    {
                        break;
                    }
                }
                // Pokud uživatel chce vrátit se zpět do menu
                else if (answer.Equals("exit"))
                {
                    return;
                }
                // Pokud uživatel zadal neplatný čas
                else
                {
                    PrintError("You have not entered a time or entered an invalid time!");
                }
            }

            // Generování náhodného časového údaje v zadaném rozsahu
            DateTime randomTime = GenerateTime(firstTime, lastTime);

            // Výpis náhodně vygenerovaného časového údaje
            Console.WriteLine($"Random time: {randomTime.ToString("H:mm")}");
        }

        /// <summary>
        /// Generuje náhodný časový údaj mezi dvěma zadanými časy.
        /// </summary>
        /// <param name="firstTime">Počáteční časový údaj.</param>
        /// <param name="lastTime">Konečný časový údaj.</param>
        /// <returns>Náhodný časový údaj mezi zadanými časy.</returns>
        public DateTime GenerateTime(DateTime firstTime, DateTime lastTime)
        {
            // Vypočítá rozdíl mezi zadanými časy
            TimeSpan timeSpan = lastTime - firstTime;

            // Získá celkový počet minut mezi zadanými časy
            int minutes = (int)timeSpan.TotalMinutes;

            // Vygeneruje náhodný počet minut v rozmezí mezi 0 a rozdílem mezi zadanými časy
            int randomMinutes = random.Next(minutes + 1);

            // Přidá náhodný počet minut k počátečnímu časovému údaji a vrátí výsledný čas
            DateTime randomTime = firstTime.AddMinutes(randomMinutes);

            return randomTime;
        }

    }
}
