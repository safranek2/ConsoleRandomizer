using ConsoleRandomizer.Randomizer.JSON_Classes;
using System;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Třída pro házení hracích kostek a zpracování uživatelského vstupu.
    /// </summary>
    public class DiceRoll
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

        private Random random = new Random(); // Instance pro generování náhodných čísel
        private ErrorController errorController = new ErrorController(); // Instance pro správu chyb

        private int minDice; // Minimální počet kostek
        private int maxDice; // Maximální počet kostek
        private int minSides; // Minimální počet stran kostky
        private int maxSides; // Maximální počet stran kostky

        /// <summary>
        /// Zobrazí menu pro házení kostek a zpracuje uživatelský vstup.
        /// </summary>
        public void Display()
        {
            int count = 0; // Počet kostek
            int sides = 0; // Počet stran kostky

            // Vyzve uživatele k zadání počtu kostek
            while (true)
            {
                Console.Write($"Enter the number of dice ({minDice}-{maxDice}) or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                if (answer.Equals("exit"))
                {
                    return;
                }

                if (Int32.TryParse(answer, out count))
                {
                    if (count >= minDice && count <= maxDice)
                    {
                        break;
                    }
                    else
                    {
                        errorController.PrintError($"You have entered a number out of range {minDice}-{maxDice}!");
                    }
                }
                else
                {
                    errorController.PrintError("You didn't enter a valid number!");
                }
            }

            // Vyzve uživatele k zadání počtu stran kostky
            while (true)
            {
                Console.Write($"Enter the number of sides of the dice ({minSides}-{maxSides}) or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                if (answer.Equals("exit"))
                {
                    return;
                }

                if (Int32.TryParse(answer, out sides))
                {
                    if (sides >= minSides && sides <= maxSides)
                    {
                        break;
                    }
                    else
                    {
                        errorController.PrintError($"You have entered a number out of range {minSides}-{maxSides}!");
                    }
                }
                else
                {
                    errorController.PrintError("You didn't enter a valid number!");
                }
            }

            // Generuje a zobrazí hodnoty po házení kostkami
            GenerateDices(count, sides);
        }

        /// <summary>
        /// Generuje a zobrazí hodnoty po házení kostkami.
        /// </summary>
        /// <param name="count">Počet kostek.</param>
        /// <param name="sides">Počet stran kostky.</param>
        public void GenerateDices(int count, int sides)
        {
            int results = 0; // Celkový součet hodnot kostek

            Console.Write("Rolled dice(s): ");

            for (int i = 0; i < count; i++)
            {
                // Hází kostkou
                int number = random.Next(1, sides + 1);
                results += number;

                // Zobrazí výsledek každého hodu kostkou
                if (i == 0)
                {
                    Console.Write(number);
                }
                else
                {
                    Console.Write($" + {number}");
                }
            }

            // Zobrazí celkový součet všech hodů kostek
            if (count > 1)
                Console.WriteLine($" = {results}");
            else
                Console.WriteLine();
        }
    }
}
