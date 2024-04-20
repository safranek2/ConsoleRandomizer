using System;
using System.Collections.Generic;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Třída reprezentující hlavní menu pro ovládání různých generátorů náhodných prvků.
    /// </summary>
    public class RandomizerMenu : RandomizerBase
    {
        /// <summary>
        /// Konstruktor třídy RandomizerMenu, inicializuje instance různých generátorů náhodných prvků.
        /// </summary>
        public RandomizerMenu()
        {
            numberGenerator = new NumbersGenerator();
            optionsGenerator = new OptionsGenerator();
            diceRoll = new DiceRoll();
            colorGenerator = new ColorGenerator();
            letterGenerator = new LetterGenerator();
            teamsGenerator = new TeamsGenerator();
            listGenerator = new ListGenerator();
            cardGenerator = new CardGenerator();
            countryGenerator = new CountryGenerator();
            dateGenerator = new DateGenerator();
            timeGenerator = new TimeGenerator();
            passwordGenerator = new PasswordGenerator();
            magic8Ball = new Magic8Ball();
        }

        // Instance generátorů náhodných prvků
        private readonly NumbersGenerator numberGenerator;
        private readonly OptionsGenerator optionsGenerator;
        private readonly DiceRoll diceRoll;
        private readonly ColorGenerator colorGenerator;
        private readonly LetterGenerator letterGenerator;
        private readonly TeamsGenerator teamsGenerator;
        private readonly ListGenerator listGenerator;
        private readonly CardGenerator cardGenerator;
        private readonly CountryGenerator countryGenerator;
        private readonly DateGenerator dateGenerator;
        private readonly TimeGenerator timeGenerator;
        private readonly PasswordGenerator passwordGenerator;
        private readonly Magic8Ball magic8Ball;

        /// <summary>
        /// Zobrazuje hlavní menu a zpracovává volbu uživatele.
        /// </summary>
        public override void Display()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine(GetMainMenu());
                Console.Write("Enter your choice: ");

                string answer = Console.ReadLine();

                if (answer.Equals("0"))
                {
                    Environment.Exit(0);
                }
                else if (Int32.TryParse(answer, out int choice))
                {
                    switch (choice)
                    {
                        // Rozlišení výběru uživatele a zobrazení odpovídajícího podmenu
                        case 1:
                            Console.WriteLine(GetRandomizerMenu("║              Numbers               ║"));
                            numberGenerator.Display();
                            break;
                        case 2:
                            Console.WriteLine(GetRandomizerMenu("║             Yes or No              ║"));
                            optionsGenerator.Display(new List<string> { "Yes", "No" });
                            break;
                        case 3:
                            Console.WriteLine(GetRandomizerMenu("║             Coin Flip              ║"));
                            optionsGenerator.Display(new List<string> { "Heads", "Tails" });
                            break;
                        case 4:

                            Console.WriteLine(GetRandomizerMenu("║       Rock, Paper, Scissors        ║"));
                            optionsGenerator.Display(new List<string> { "Rock", "Paper", "Scissors" });
                            break;
                        case 5:
                            Console.WriteLine(GetRandomizerMenu("║              Dice Roll             ║"));
                            diceRoll.Display();
                            break;
                        case 6:
                            Console.WriteLine(GetRandomizerMenu("║               Colors               ║"));
                            colorGenerator.Display();
                            break;
                        case 7:
                            Console.WriteLine(GetRandomizerMenu("║               Letters              ║"));
                            letterGenerator.Display();
                            break;
                        case 8:
                            Console.WriteLine(GetRandomizerMenu("║                Teams               ║"));
                            teamsGenerator.Display();
                            break;
                        case 9:
                            Console.WriteLine(GetRandomizerMenu("║                List                ║"));
                            listGenerator.Display();
                            break;
                        case 10:
                            Console.WriteLine(GetRandomizerMenu("║                Card                ║"));
                            cardGenerator.Display();
                            break;
                        case 11:
                            Console.WriteLine(GetRandomizerMenu("║              Country               ║"));
                            countryGenerator.Display();
                            break;
                        case 12:
                            Console.WriteLine(GetRandomizerMenu("║                Date                ║"));
                            dateGenerator.Display();
                            break;
                        case 13:
                            Console.WriteLine(GetRandomizerMenu("║                Time                ║"));
                            timeGenerator.Display();
                            break;
                        case 14:
                            Console.WriteLine(GetRandomizerMenu("║              Password              ║"));
                            passwordGenerator.Display();
                            break;
                        case 15:
                            Console.WriteLine(GetRandomizerMenu("║            Magic 8 Ball            ║"));
                            magic8Ball.Display();
                            break;
                        default:
                            PrintError("You did not enter the number 1-15");
                            break;
                    }
                }
                else
                {
                    PrintError("You did not enter the number 1-15!");
                }
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Vrací hlavní menu s výběrem možností pro uživatele.
        /// </summary>
        /// <param name="clearConsole">Určuje, zda se má konzole vyčistit před zobrazením menu.</param>
        /// <returns>Text hlavního menu.</returns>
        public string GetMainMenu(bool clearConsole = true)
        {
            if (clearConsole)
            {
                Console.Clear();
            }

            string menu =
                $"╔════════════════════════════════════╗{Environment.NewLine}" +
                $"║         Console Randomizer         ║{Environment.NewLine}" +
                $"╠════════════════════════════════════╣{Environment.NewLine}" +
                $"║                Menu                ║{Environment.NewLine}" +
                $"╠════════════════════════════════════╣{Environment.NewLine}" +
                $"║ 1) Numbers                         ║{Environment.NewLine}" +
                $"║ 2) Yes or No                       ║{Environment.NewLine}" +
                $"║ 3) Coin Flip                       ║{Environment.NewLine}" +
                $"║ 4) Rock, Paper, Scissors           ║{Environment.NewLine}" +
                $"║ 5) Dice Rolls                      ║{Environment.NewLine}" +
                $"║ 6) Colors                          ║{Environment.NewLine}" +
                $"║ 7) Letters                         ║{Environment.NewLine}" +
                $"║ 8) Teams                           ║{Environment.NewLine}" +
                $"║ 9) List                            ║{Environment.NewLine}" +
                $"║ 10) Card                           ║{Environment.NewLine}" +
                $"║ 11) Country                        ║{Environment.NewLine}" +
                $"║ 12) Date                           ║{Environment.NewLine}" +
                $"║ 13) Time                           ║{Environment.NewLine}" +
                $"║ 14) Password                       ║{Environment.NewLine}" +
                $"║ 15) Magic 8 Ball                   ║{Environment.NewLine}" +
                $"║ 0) Exit                            ║{Environment.NewLine}" +
                $"╚════════════════════════════════════╝";

            return menu;
        }

        /// <summary>
        /// Vrací podmenu s názvem zvolené funkce pro generování náhodných prvků.
        /// </summary>
        /// <param name="title">Název zvolené funkce.</param>
        /// <param name="clearConsole">Určuje, zda se má konzole vyčistit před zobrazením menu.</param>
        /// <returns>Text podmenu.</returns>
        public string GetRandomizerMenu(string title, bool clearConsole = true)
        {
            if (clearConsole)
            {
                Console.Clear();
            }

            string menu = $"╔════════════════════════════════════╗{Environment.NewLine}" +
                          $"║         Console Randomizer         ║{Environment.NewLine}" +
                          $"╠════════════════════════════════════╣{Environment.NewLine}" +
                          $"{title}{Environment.NewLine}" +
                          $"╚════════════════════════════════════╝";

            return menu;
        }
    }
}
