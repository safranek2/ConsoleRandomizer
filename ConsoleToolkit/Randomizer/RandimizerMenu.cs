using System;
using System.Collections.Generic;

namespace ConsoleToolkit
{
    /// <summary>
    /// Třída reprezentující hlavní menu pro konzolový náhodný generátor.
    /// </summary>
    internal class RandomizerMenu
    {
        /// <summary>
        /// Konstruktor třídy RandomizerMenu. Inicializuje instance jednotlivých generátorů.
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
        private NumbersGenerator numberGenerator;
        private OptionsGenerator optionsGenerator;
        private DiceRoll diceRoll;
        private ColorGenerator colorGenerator;
        private LetterGenerator letterGenerator;
        private TeamsGenerator teamsGenerator;
        private ListGenerator listGenerator;
        private CardGenerator cardGenerator;
        private CountryGenerator countryGenerator;
        private DateGenerator dateGenerator;
        private TimeGenerator timeGenerator;
        private PasswordGenerator passwordGenerator;
        private Magic8Ball magic8Ball;

        /// <summary>
        /// Zobrazí hlavní menu a zpracuje vstup od uživatele.
        /// </summary>
        public void Display()
        {
            // Nastaví kódování pro výstup konzole pro zvládnutí speciálních znaků
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                // Zobrazení možností menu
                Console.WriteLine("╔════════════════════════════════════╗");
                Console.WriteLine("║         Console Randomizer         ║");
                Console.WriteLine("╠════════════════════════════════════╣");
                Console.WriteLine("║                Menu                ║");
                Console.WriteLine("╠════════════════════════════════════╣");
                Console.WriteLine("║ 1) Numbers                         ║");
                Console.WriteLine("║ 2) Yes or No                       ║");
                Console.WriteLine("║ 3) Coin Flip                       ║");
                Console.WriteLine("║ 4) Rock, Paper, Scissors           ║");
                Console.WriteLine("║ 5) Dice Rolls                      ║");
                Console.WriteLine("║ 6) Colors                          ║");
                Console.WriteLine("║ 7) Letters                         ║");
                Console.WriteLine("║ 8) Teams                           ║");
                Console.WriteLine("║ 9) List                            ║");
                Console.WriteLine("║ 10) Card                           ║");
                Console.WriteLine("║ 11) Country                        ║");
                Console.WriteLine("║ 12) Date                           ║");
                Console.WriteLine("║ 13) Time                           ║");
                Console.WriteLine("║ 14) Password                       ║");
                Console.WriteLine("║ 15) Magic 8 Ball                   ║");
                Console.WriteLine("║ 0) Exit                            ║");
                Console.WriteLine("╚════════════════════════════════════╝");
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
                            DisplayMenu("║               Numbers              ║");
                            numberGenerator.Display();
                            break;
                        case 2:
                            DisplayMenu("║              Yes or No             ║");
                            optionsGenerator.Display(new List<string> { "Yes", "No" });
                            break;
                        case 3:
                            DisplayMenu("║              Coin Flip             ║");
                            optionsGenerator.Display(new List<string> { "Heads", "Tails" });
                            break;
                        case 4:

                            DisplayMenu("║       Rock, Paper, Scissors        ║");
                            optionsGenerator.Display(new List<string> { "Rock", "Paper", "Scissors" });
                            break;
                        case 5:
                            DisplayMenu("║              Dice Roll             ║");
                            diceRoll.Display();
                            break;
                        case 6:
                            DisplayMenu("║              Dice Roll             ║");
                            DisplayMenu("║                Color               ║");
                            colorGenerator.Display();
                            break;
                        case 7:
                            DisplayMenu("║               Letter               ║");
                            letterGenerator.Display();
                            break;
                        case 8:
                            DisplayMenu("║                Teams               ║");
                            teamsGenerator.Display();
                            break;
                        case 9:
                            DisplayMenu("║                 List               ║");
                            listGenerator.Display();
                            break;
                        case 10:
                            DisplayMenu("║                 Card               ║");
                            cardGenerator.Display();
                            break;
                        case 11:
                            DisplayMenu("║               Country              ║");
                            countryGenerator.Display();
                            break;
                        case 12:
                            DisplayMenu("║                 Date               ║");
                            dateGenerator.Display();
                            break;
                        case 13:
                            DisplayMenu("║                 Time               ║");
                            timeGenerator.Display();
                            break;
                        case 14:
                            DisplayMenu("║              Password              ║");
                            passwordGenerator.Display();
                            break;
                        case 15:
                            DisplayMenu("║            Magic 8 Ball            ║");
                            magic8Ball.Display();
                            break;
                    }
                    Console.WriteLine("Press any key to continue . . .");
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Metoda pro zobrazení menu s titulkem.
        /// </summary>
        /// <param name="title">Titulek menu.</param>
        private void DisplayMenu(string title)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║         Console Randomizer         ║");
            Console.WriteLine("╠════════════════════════════════════╣");
            Console.WriteLine(title);
            Console.WriteLine("╚════════════════════════════════════╝");
        }
    }
}
