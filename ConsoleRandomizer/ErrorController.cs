using System;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Třída pro řízení a zobrazení chybových zpráv v konzoli.
    /// </summary>
    public class ErrorController
    {
        /// <summary>
        /// Konstruktor třídy ErrorController.
        /// </summary>
        public ErrorController()
        {
            // Prázdný konstruktor, žádné speciální inicializace není potřebná.
        }

        /// <summary>
        /// Metoda pro zobrazení chybové zprávy v červené barvě v konzoli.
        /// </summary>
        /// <param name="message">Text chybové zprávy.</param>
        public void PrintError(string message)
        {
            // Nastavení barvy textu na červenou pro výpis chybové zprávy
            Console.ForegroundColor = ConsoleColor.Red;

            // Výpis chybové zprávy do konzole
            Console.WriteLine(message);

            // Resetování barvy konzole zpět na výchozí hodnotu
            Console.ResetColor();
        }
    }
}
