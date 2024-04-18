using ConsoleRandomizer.Randomizer.JSON_Classes;
using System;
using System.Collections.Generic;

namespace ConsoleRandomizer
{

    /// <summary>
    /// Třída pro generování náhodných čísel na základě uživatelem definovaných parametrů.
    /// </summary>
    public class NumbersGenerator
    {
        /// <summary>
        /// Konstruktor třídy NumbersGenerator. Načítá nastavení pro generování čísel z JSON souboru.
        /// </summary>
        public NumbersGenerator()
        {
            JSONLoader jsonLoader = new JSONLoader();
            NumbersSettings numbersSettings = jsonLoader.LoadNumbersSettingsFromJSON();
            minNumbers = numbersSettings.MinNumbers;
            maxNumbers = numbersSettings.MaxNumbers;
        }

        private readonly Random random = new Random();
        private readonly ErrorController errorController = new ErrorController();

        private readonly int minNumbers; // Minimální počet čísel, které lze vygenerovat.
        private readonly int maxNumbers; // Maximální počet čísel, které lze vygenerovat.

        /// <summary>
        /// Zobrazí uživatelské rozhraní pro generování čísel.
        /// </summary>
        public void Display()
        {
            // Kontrola, zda je povoleno generování čísel.
            if (maxNumbers > 0)
            {
                int count;
                int min;
                int max;
                bool repetitions = false; // Příznak pro kontrolu, zda jsou povoleny opakující se čísla.

                // Vstup počtu čísel od uživatele.
                while (true)
                {
                    Console.Write($"Enter a number of numbers from {minNumbers} to {maxNumbers} or 'exit' to return to the menu: ");
                    string answer = Console.ReadLine();

                    if (Int32.TryParse(answer, out count))
                    {
                        if (count >= minNumbers && count <= maxNumbers)
                        {
                            break;
                        }
                        else
                        {
                            errorController.PrintError($"You entered a number outside the range of {minNumbers}-{maxNumbers}!");
                        }
                    }
                    else if (answer.Equals("exit"))
                    {
                        return;
                    }
                    else
                    {
                        errorController.PrintError("You didn't write a number!");
                    }
                }

                // Pokud uživatel chce generovat více než jedno číslo, zeptáme se na opakování.
                if (count > 1)
                {
                    while (true)
                    {
                        Console.Write("Enter 1 if you want the number to be repeated or 'exit' to return to the menu: ");
                        string answer = Console.ReadLine();

                        if (answer.Equals("1"))
                        {
                            repetitions = true;
                            break;
                        }
                        else if (answer.Equals("exit"))
                        {
                            return;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                // Načítání minimální hodnoty od uživatele
                while (true)
                {
                    Console.Write("Enter a minimum number or 'exit' to return to the menu: ");
                    string answer = Console.ReadLine();

                    if (Int32.TryParse(answer, out min))
                    {
                        break;
                    }
                    else if (answer.Equals("exit"))
                    {
                        return;
                    }
                    else
                    {
                        errorController.PrintError("You didn't write a number!");
                    }
                }

                // Načítání maximální hodnoty od uživatele
                while (true)
                {
                    Console.Write("Enter a maximum number or 'exit' to return to the menu: ");
                    string answer = Console.ReadLine();

                    if (Int32.TryParse(answer, out max))
                    {
                        // Pokud opakování není povoleno, kontrolujeme, zda je maximální hodnota větší nebo rovna minimální hodnotě plus počtu čísel mínus 1
                        if (!repetitions && max >= min + count - 1)
                        {
                            break;
                        }
                        // Pokud opakování není povoleno a podmínka není splněna, vypisujeme chybu
                        else if (!repetitions)
                        {
                            errorController.PrintError("Max number must be a larger or equal number than minimum number plus number of numbers!");
                        }
                        // Pokud opakování je povoleno a maximální číslo je větší než minimální
                        else if (max > min)
                        {
                            break;
                        }
                        else
                        {
                            errorController.PrintError("Max number must be a larger number than minimum number!");
                        }
                    }
                    else if (answer.Equals("exit"))
                    {
                        return;
                    }
                    else
                    {
                        errorController.PrintError("You didn't write a number!");
                    }
                }

                // Generování a výpis čísel
                GenerateNumbers(count, min, max, repetitions);
            }
        }

        /// <summary>
        /// Generuje a vypisuje náhodná čísla na základě zadaných vstupů.
        /// </summary>
        /// <param name="count">Počet čísel k vygenerování.</param>
        /// <param name="min">Minimální hodnota čísla.</param>
        /// <param name="max">Maximální hodnota čísla.</param>
        /// <param name="repetitions">Příznak, zda jsou povoleny opakování čísel.</param>
        public void GenerateNumbers(int count, int min, int max, bool repetitions)
        {
            List<int> numbers = new List<int>(); // Seznam pro uchování vygenerovaných čísel

            for (int i = 1; i <= count; i++)
            {
                int number = random.Next(min, max + 1);

                // Pokud opakování není povoleno a číslo již bylo vygenerováno, vygenerujte nové číslo
                while (!repetitions && numbers.Contains(number))
                {
                    number = random.Next(min, max + 1);
                }

                // Výpis čísla na konzoli a přidání ho do seznamu
                Console.WriteLine(i + ") " + number);
                numbers.Add(number);
            }
        }
    }
}