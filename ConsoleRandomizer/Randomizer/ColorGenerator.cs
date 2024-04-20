using ConsoleRandomizer.vendor; // Importuje vendor pro ClosestConsoleColor
using System;
using System.Drawing;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Třída pro generování náhodných barev a hledání nejbližší konzolové barvy.
    /// </summary>
    public class ColorGenerator : RandomizerBase
    {
        /// <summary>
        /// Konstruktor třídy ColorGenerator.
        /// Inicializuje instanci třídy ClosestConsoleColor.
        /// </summary>
        public ColorGenerator()
        {
            closestConsoleColor = new ClosestConsoleColor();
        }

        private readonly ClosestConsoleColor closestConsoleColor; // Instance třídy pro nalezení nejbližší barvy v konzoli

        /// <summary>
        /// Metoda pro zobrazení náhodné barvy a nejbližší konzolové barvy.
        /// </summary>
        public override void Display()
        {
            // Generuje náhodnou barvu
            string color = GenerateRandomColor();

            // Vypočítá nejbližší barvu v konzoli
            ConsoleColor closestColor = closestConsoleColor.Calculate(color);

            // Vypíše náhodnou barvu
            Console.WriteLine($"Random color: {color}");

            // Nastaví kontrastní barvu textu konzole na základě barvy pozadí
            SetConsoleContrastForegroundColor(color);

            // Nastaví barvu pozadí konzole na nejbližší barvu
            SetConsoleBackgroundColor(closestColor);

            // Vypíše informaci o nejbližší konzolové barvě
            Console.WriteLine($"The closest console color (this background color) to {color} is {closestColor}");

            // Resetuje barvu pozadí konzole zpět na černou
            ResetConsoleColors();
        }

        /// <summary>
        /// Metoda pro generování náhodné barvy v hexadecimálním formátu.
        /// </summary>
        /// <returns>Řetězec představující náhodnou barvu v hexadecimálním formátu.</returns>
        public string GenerateRandomColor()
        {
            // Generuje náhodné hodnoty pro složky RGB
            int red = random.Next(256);
            int green = random.Next(256);
            int blue = random.Next(256);

            // Sestaví hexadecimální reprezentaci barvy
            string color = $"#{red:X2}{green:X2}{blue:X2}";

            return color;
        }

        /// <summary>
        /// Metoda pro nastavení kontrastní barvy textu konzole na základě vstupní barvy pozadí.
        /// </summary>
        /// <param name="hexColor">Hexadecimální kód barvy pozadí konzole.</param>
        public void SetConsoleContrastForegroundColor(string hexColor)
        {
            Color backgroundColor = ColorTranslator.FromHtml(hexColor);

            // Vypočítá kontrastní barvu textu na základě barvy pozadí
            Color foregroundColor = CalculateContrastColor(backgroundColor);

            // Získá hexadecimální kód kontrastní barvy
            string foregroundColorHex = ColorTranslator.ToHtml(foregroundColor);

            // Vyhodnotí nejbližší konzolovou barvu k dané kontrastní barvě
            ConsoleColor closestForegroundColor = closestConsoleColor.Calculate(foregroundColorHex);

            // Nastaví barvu textu konzole podle nejbližší konzolové barvy
            Console.ForegroundColor = closestForegroundColor;
        }

        /// <summary>
        /// Metoda pro výpočet kontrastní barvy textu na základě barvy pozadí.
        /// </summary>
        /// <param name="backgroundColor">Barva pozadí.</param>
        /// <returns>Kontrastní barva textu.</returns>
        public Color CalculateContrastColor(Color backgroundColor)
        {
            // Vypočítá průměrnou hodnotu jasu (luminance) barvy pozadí
            double luminance = (0.299 * backgroundColor.R + 0.587 * backgroundColor.G + 0.114 * backgroundColor.B) / 255;

            // Určí kontrastní barvu textu na základě jasu pozadí
            return luminance > 0.5 ? Color.Black : Color.White;
        }

        /// <summary>
        /// Metoda pro nastavení barvy pozadí konzole.
        /// </summary>
        /// <param name="color">Barva, která se má nastavit jako pozadí konzole.</param>
        public void SetConsoleBackgroundColor(ConsoleColor color)
        {
            // Nastaví barvu pozadí konzole podle parametru color
            Console.BackgroundColor = color;
        }

        /// <summary>
        /// Metoda pro resetování barvy pozadí konzole na černou.
        /// </summary>
        public void ResetConsoleColors()
        {
            // Obnoví barvy konzole
            Console.ResetColor();
        }
    }
}
