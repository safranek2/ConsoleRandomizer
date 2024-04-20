using ConsoleRandomizer.Randomizer.JSON_Classes;
using System;
using System.Collections.Generic;

namespace ConsoleRandomizer
{

    /// <summary>
    /// Třída pro generování náhodných čísel na základě uživatelem definovaných parametrů.
    /// </summary>
    public class NumbersGenerator : RandomizerBase
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

        private readonly int minNumbers; // Minimální počet čísel, které lze vygenerovat.
        private readonly int maxNumbers; // Maximální počet čísel, které lze vygenerovat.

        /// <summary>
        /// Zobrazuje uživatelské rozhraní pro generování seznamu náhodných čísel a zpracovává uživatelský vstup.
        /// </summary>
        public override void Display()
        {
            // Kontrola, zda je nastaveno maximální číslo pro generování náhodných čísel
            if (maxNumbers > 0)
            {
                int count; // Počet čísel ke generování
                int min; // Minimální hodnota generovaných čísel
                int max; // Maximální hodnota generovaných čísel
                bool repetitions = false; // Příznak, zda se čísla mohou opakovat

                // Získání od uživatele počtu čísel ke generování
                while (true)
                {
                    Console.Write($"Enter a number of numbers from {minNumbers} to {maxNumbers} or 'exit' to return to the menu: ");

                    string answer = Console.ReadLine();

                    if (Int32.TryParse(answer, out count))
                    {
                        // Kontrola platnosti zadaného počtu čísel
                        if (count >= minNumbers && count <= maxNumbers)
                        {
                            break;
                        }
                        else
                        {
                            PrintError($"You entered a number outside the range of {minNumbers}-{maxNumbers}!");
                        }
                    }
                    else if (answer.Equals("exit"))
                    {
                        return;
                    }
                    else
                    {
                        PrintError("You didn't write a number!");
                    }
                }

                // Získání od uživatele informace o opakování čísel, pokud počet čísel je větší než 1
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

                // Získání od uživatele minimálního čísla
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
                        PrintError("You didn't write a number!");
                    }
                }

                // Získání od uživatele maximálního čísla
                while (true)
                {
                    Console.Write("Enter a maximum number or 'exit' to return to the menu: ");
                    string answer = Console.ReadLine();

                    if (Int32.TryParse(answer, out max))
                    {
                        // Kontrola platnosti vstupního rozsahu čísel
                        if (!repetitions && max >= min + count - 1)
                        {
                            break;
                        }
                        else if (!repetitions)
                        {
                            PrintError("Max number must be a larger or equal number than minimum number plus number of numbers!");
                        }
                        else if (max > min)
                        {
                            break;
                        }
                        else
                        {
                            PrintError("Max number must be a larger number than minimum number!");
                        }
                    }
                    else if (answer.Equals("exit"))
                    {
                        return;
                    }
                    else
                    {
                        PrintError("You didn't write a number!");
                    }
                }

                // Generování seznamu náhodných čísel a následně jeho vypsání
                List<int> generatedNumbers = GenerateNumbers(count, min, max, repetitions);
                string generatedNumbersAsString = NumbersAsString(generatedNumbers);
                Console.WriteLine(generatedNumbersAsString);
            }
        }

        /// <summary>
        /// Generuje seznam náhodných celých čísel.
        /// </summary>
        /// <param name="count">Počet čísel, které mají být vygenerovány.</param>
        /// <param name="min">Minimální hodnota, která může být vygenerována.</param>
        /// <param name="max">Maximální hodnota, která může být vygenerována.</param>
        /// <param name="repetitions">Určuje, zda mají být povoleny opakující se čísla ve výsledném seznamu.</param>
        /// <returns>Seznam náhodných celých čísel.</returns>
        public List<int> GenerateNumbers(int count, int min, int max, bool repetitions)
        {
            List<int> numbers = new List<int>();

            for (int i = 1; i <= count; i++)
            {
                int number;

                do
                {
                    number = random.Next(min, max + 1);
                } while (!repetitions && numbers.Contains(number)); // Pokud opakování není povoleno a číslo již existuje v seznamu, vygeneruje se nové číslo

                numbers.Add(number);
            }

            return numbers;
        }

        /// <summary>
        /// Převádí seznam čísel na textový řetězec ve formátu indexovaného seznamu.
        /// </summary>
        /// <param name="numbers">Seznam čísel, který má být převeden.</param>
        /// <returns>Textový řetězec obsahující čísla ve formátu indexovaného seznamu.</returns>
        public string NumbersAsString(List<int> numbers)
        {
            string result = "";
            for (int i = 0; i < numbers.Count; i++)
            {
                result += $"{i + 1}) {numbers[i]}"; // Indexace začíná od 1, protože seznamy jsou obvykle indexovány od 1 pro uživatelské rozhraní.
            }

            return result;
        }

    }
}