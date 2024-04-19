using System;
using System.Collections.Generic;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Třída reprezentující hlavní menu pro konzolový náhodný generátor.
    /// </summary>
    public class RandomizerMenu : RandomizerBase
    {
        /// <summary>
        /// Konstruktor třídy RandomizerMenu. Inicializuje instance jednotlivých generátorů a třidy pro výpis chyby.
        /// </summary>
        public RandomizerMenu()
        {
            // Inicializace proměnných třídy
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

        // Deklarace proměnných třídy
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
        /// Zobrazí hlavní menu a zpracuje vstup od uživatele.
        /// </summary>
        public override void Display()
        {
            // Nastavení kódování pro výstup konzole pro zvládnutí speciálních znaků
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine(GetMainMenu());
                Console.Write("Enter your choice: ");
                string answer = Console.ReadLine();

                if (answer.Equals("0"))
                {
                    // Ukončí aplikaci, pokud uživatel zvolí ukončení
                    Environment.Exit(0);
                }
                else if (Int32.TryParse(answer, out int choice))
                {
                    switch (choice)
                    {
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
        /// Metoda pro sestavení a vrácení obsahu menu.
        /// </summary>
        /// <param name="clearConsole">Určuje, zda se má konzole vyčistit před zobrazením menu.</param>
        /// <returns>Textový obsah menu.</returns>
        public string GetMainMenu(bool clearConsole = true)
        {
            if (clearConsole)
            {
                Console.Clear();
            }

            // Sestavení obsahu menu do řetězce
            string menu =
                "╔════════════════════════════════════╗\n" +
                "║         Console Randomizer         ║\n" +
                "╠════════════════════════════════════╣\n" +
                "║                Menu                ║\n" +
                "╠════════════════════════════════════╣\n" +
                "║ 1) Numbers                         ║\n" +
                "║ 2) Yes or No                       ║\n" +
                "║ 3) Coin Flip                       ║\n" +
                "║ 4) Rock, Paper, Scissors           ║\n" +
                "║ 5) Dice Rolls                      ║\n" +
                "║ 6) Colors                          ║\n" +
                "║ 7) Letters                         ║\n" +
                "║ 8) Teams                           ║\n" +
                "║ 9) List                            ║\n" +
                "║ 10) Card                           ║\n" +
                "║ 11) Country                        ║\n" +
                "║ 12) Date                           ║\n" +
                "║ 13) Time                           ║\n" +
                "║ 14) Password                       ║\n" +
                "║ 15) Magic 8 Ball                   ║\n" +
                "║ 0) Exit                            ║\n" +
                "╚════════════════════════════════════╝";

            // Vrácení sestaveného menu
            return menu;
        }


        /// <summary>
        /// Metoda pro sestavení a vrácení textového obsahu menu s titulkem.
        /// </summary>
        /// <param name="title">Titulek menu.</param>
        /// <param name="clearConsole">Určuje, zda se má konzole vyčistit před zobrazením menu.</param>
        /// <returns>Textový obsah menu.</returns>
        public string GetRandomizerMenu(string title, bool clearConsole = true)
        {
            if (clearConsole)
            {
                Console.Clear();
            }

            // Sestavení obsahu menu do řetězce
            string menu = $"╔════════════════════════════════════╗{Environment.NewLine}" +
                          $"║         Console Randomizer         ║{Environment.NewLine}" +
                          $"╠════════════════════════════════════╣{Environment.NewLine}" +
                          $"{title}{Environment.NewLine}" +
                          $"╚════════════════════════════════════╝";

            // Vrácení sestaveného menu
            return menu;
        }
    }
}
