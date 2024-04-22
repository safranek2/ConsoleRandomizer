using ConsoleRandomizer.Randomizer.JSON_Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Třída pro házení hracích kostek a zpracování uživatelského vstupu.
    /// </summary>
    public class DiceRoll : RandomizerBase
    {
        /// <summary>
        /// Konstruktor třídy DiceRoll.
        /// </summary>
        public DiceRoll()
        {
            JSONLoader jsonLoader = new JSONLoader();
            DiceSettings diceSettings = jsonLoader.LoadDiceSettingsFromJSON();

            // Nastavení minimálního a maximálního počtu kostek a stran kostek
            minDice = diceSettings.MinDice;
            maxDice = diceSettings.MaxDice;
            minSides = diceSettings.MinSides;
            maxSides = diceSettings.MaxSides;
        }

        private int minDice; // Minimální počet kostek
        private int maxDice; // Maximální počet kostek
        private int minSides; // Minimální počet stran kostky
        private int maxSides; // Maximální počet stran kostky

        /// <summary>
        /// Zobrazuje uživatelské rozhraní pro házení hracích kostek a zpracovává uživatelský vstup.
        /// </summary>
        public override void Display()
        {
            int count = 0; // Počet kostek
            int sides = 0; // Počet stran kostky

            while (true)
            {
                // Vyzve uživatele k zadání počtu kostek
                Console.Write($"Enter the number of dice ({minDice}-{maxDice}) or 'exit' to return to the menu: ");

                string answer = Console.ReadLine();

                // Pokud uživatel zvolil ukončení, metoda se vrátí zpět do menu
                if (answer.Equals("exit"))
                {
                    return;
                }

                // Pokusí se načíst počet kostek z uživatelského vstupu
                if (Int32.TryParse(answer, out count))
                {
                    // Kontroluje, zda zadaný počet kostek je v povoleném rozmezí
                    if (count >= minDice && count <= maxDice)
                    {
                        break; // Pokud je počet kostek v povoleném rozmezí, ukončí smyčku
                    }
                    else
                    {
                        PrintError($"You have entered a number out of range {minDice}-{maxDice}!"); // Pokud je počet kostek mimo povolený rozsah, vypíše chybovou zprávu
                    }
                }
                else
                {
                    PrintError("You didn't enter a valid number!"); // Pokud uživatel nezadá platné číslo, vypíše chybovou zprávu
                }
            }

            while (true)
            {
                // Vyzve uživatele k zadání počtu stran kostky
                Console.Write($"Enter the number of sides of the dice ({minSides}-{maxSides}) or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                // Pokud uživatel zvolil ukončení, metoda se vrátí zpět do menu
                if (answer.Equals("exit"))
                {
                    return;
                }

                // Pokusí se načíst počet stran kostky z uživatelského vstupu
                if (Int32.TryParse(answer, out sides))
                {
                    // Kontroluje, zda zadaný počet stran kostky je v povoleném rozmezí
                    if (sides >= minSides && sides <= maxSides)
                    {
                        break; // Pokud je počet stran kostky v povoleném rozmezí, ukončí smyčku
                    }
                    else
                    {
                        PrintError($"You have entered a number out of range {minSides}-{maxSides}!"); // Pokud je počet stran kostky mimo povolený rozsah, vypíše chybovou zprávu
                    }
                }
                else
                {
                    PrintError("You didn't enter a valid number!"); // Pokud uživatel nezadá platné číslo, vypíše chybovou zprávu
                }
            }

            // Generuje hodnoty po házení kostkami a zobrazí výsledek
            List<int> generatedDiceList = GenerateDiceList(count, sides);
            string generatedDiceListAsString = GenerateDiceListAsString(generatedDiceList);
            Console.WriteLine(generatedDiceListAsString);
        }

        /// <summary>
        /// Generuje seznam hodnot kostek na základě počtu kostek a počtu stran na každé kostce.
        /// </summary>
        /// <param name="count">Počet kostek, které mají být vygenerovány.</param>
        /// <param name="sides">Počet stran na každé kostce.</param>
        /// <returns>Seznam obsahující vygenerované hodnoty kostek.</returns>
        public List<int> GenerateDiceList(int count, int sides)
        {
            List<int> diceList = new List<int>(); // Inicializuje prázdný seznam pro ukládání hodnot kostek

            // Prochází cyklem počet kostek
            for (int i = 0; i < count; i++)
            {
                int number = random.Next(1, sides + 1); // Generuje náhodné číslo odpovídající jedné straně kostky
                diceList.Add(number); // Přidá vygenerovanou hodnotu kostky do seznamu
            }

            return diceList; // Vrátí seznam obsahující vygenerované hodnoty kostek
        }

        /// <summary>
        /// Generuje textový řetězec z hodnot kostek uložených v seznamu.
        /// </summary>
        /// <param name="diceValues">Seznam hodnot kostek.</param>
        /// <returns>Textový řetězec obsahující seznam hodnot kostek a jejich součet.</returns>
        public string GenerateDiceListAsString(List<int> diceValues)
        {
            string result = "Rolled dice: ";

            // Prochází seznam hodnot kostek
            for (int i = 0; i < diceValues.Count; i++)
            {
                int number = diceValues[i]; // Aktuální hodnota kostky

                // Pokud je to první hodnota kostky, přidá pouze číslo
                if (i == 0)
                {
                    result += number;
                }
                else // Jinak přidá číslo s odpovídajícím formátováním
                {
                    result += $" + {number}";
                }
            }

            // Pokud byly hozeny více než jedna kostka, přidá jejich součet
            if (diceValues.Count > 1)
            {
                int sum = diceValues.Sum(); // Spočítá součet hodnot kostek
                result += $" = {sum}"; // Přidá součet do výsledného textového řetězce
            }

            return result; // Vrátí výsledný textový řetězec obsahující hodnoty kostek a jejich součet
        }
    }
}
