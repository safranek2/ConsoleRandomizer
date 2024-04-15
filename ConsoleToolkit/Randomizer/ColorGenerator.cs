using ConsoleToolkit.vendor; // Importuje vendor pro ClosestConsoleColor
using System;

namespace ConsoleToolkit
{
    /// <summary>
    /// Třída pro generování náhodných barev a hledání nejbližší konzolové barvy.
    /// </summary>
    internal class ColorGenerator
    {
        /// <summary>
        /// Konstruktor třídy ColorGenerator.
        /// Inicializuje instanci třídy ClosestConsoleColor.
        /// </summary>
        public ColorGenerator()
        {
            closestConsoleColor = new ClosestConsoleColor();
        }

        private readonly Random random = new Random(); // Instance třídy pro generování náhodných čísel

        private readonly ClosestConsoleColor closestConsoleColor; // Instance třídy pro nalezení nejbližší barvy v konzoli


        /// <summary>
        /// Metoda pro zobrazení náhodné barvy a nejbližší konzolové barvy.
        /// </summary>
        public void Display()
        {
            // Generuje náhodnou barvu
            string color = GenerateRandomColor();

            // Vypočítá nejbližší barvu v konzoli
            ConsoleColor closestColor = closestConsoleColor.Calculate(color);

            // Vypíše náhodnou barvu
            Console.WriteLine("Random color: " + color);

            // Nastaví barvu pozadí konzole na nejbližší barvu
            SetConsoleBackgroundColor(closestColor);

            // Vypíše informaci o nejbližší konzolové barvě
            Console.WriteLine($"The closest console color to {color} is {closestColor}");

            // Resetuje barvu pozadí konzole zpět na černou
            ResetConsoleBackgroundColor();
        }

        /// <summary>
        /// Metoda pro generování náhodné barvy v hexadecimálním formátu.
        /// </summary>
        /// <returns>Řetězec představující náhodnou barvu v hexadecimálním formátu.</returns>
        private string GenerateRandomColor()
        {
            // Generuje náhodné hodnoty pro složky RGB
            int red = random.Next(256);
            int green = random.Next(256);
            int blue = random.Next(256);

            // Sestaví hexadecimální reprezentaci barvy
            string color = $"#" + red.ToString("X2") + green.ToString("X2") + blue.ToString("X2");

            return color;
        }

        /// <summary>
        /// Metoda pro nastavení barvy pozadí konzole.
        /// </summary>
        /// <param name="color">Barva, která se má nastavit jako pozadí konzole.</param>
        private void SetConsoleBackgroundColor(ConsoleColor color)
        {
            // Nastaví barvu pozadí konzole podle parametru color
            Console.BackgroundColor = color;
        }

        /// <summary>
        /// Metoda pro resetování barvy pozadí konzole na černou.
        /// </summary>
        private void ResetConsoleBackgroundColor()
        {
            // Nastaví barvu pozadí konzole na černou
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
