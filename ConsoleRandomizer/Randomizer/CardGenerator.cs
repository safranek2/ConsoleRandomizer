using System;
using System.Collections.Generic;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Třída pro generování a práci s kartami.
    /// </summary>
    public class CardGenerator : RandomizerBase
    {
        /// <summary>
        /// Konstruktor třídy CardGenerator.
        /// </summary>
        public CardGenerator()
        {
            // Prázdný konstruktor, žádná speciální inicializace není potřebná.
        }

        // Seznam hodnot (ranků) karet
        private readonly List<string> ranks = new List<string>()
        {
            "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
            "Jack", "Queen", "King", "Ace"
        };

        // Seznam barev (suits) karet
        private readonly List<string> suits = new List<string>()
        {
            "Clubs", "Diamonds", "Hearts", "Spades"
        };

        /// <summary>
        /// Metoda pro zobrazení nabídky generátoru karet a zpracování uživatelského vstupu.
        /// </summary>
        public override void Display()
        {
            while (true)
            {
                Console.WriteLine(GetOptions());

                Console.Write("Enter your choice: ");
                string answer = Console.ReadLine();

                if (int.TryParse(answer, out int intAnswer))
                {
                    if (intAnswer >= 1 && intAnswer <= 6)
                    {
                        List<string> deck = CreateDeck(intAnswer);
                        string randomCard = DrawCard(deck);
                        Console.WriteLine($"Random card: {randomCard}");
                        break;
                    }
                    else if (intAnswer == 0)
                    {
                        return;
                    }
                    else
                    {
                        PrintError("You have entered an invalid number!");
                    }
                }
                else
                {
                    PrintError("You didn't enter a number!");
                }
            }
        }

        public static string GetOptions()
        {
            string options = @"Options:
                    1) Draw a card from the standard 52-card deck
                    2) Draw a card from a 54-card deck with 2 Jokers
                    3) Draw a card from a 56-card deck with 4 Jokers
                    4) Draw a card from a 36-card deck (6-A)
                    5) Draw a card from a 32-card deck (7-A)
                    6) Draw a card from a 24-card deck (9-A)
                    0) Exit";

            return options;
        }


        /// <summary>
        /// Metoda pro vytvoření balíčku karet na základě vstupu uživatele.
        /// </summary>
        /// <param name="choice">Vstup uživatele určující typ balíčku karet.</param>
        /// <returns>Seznam karet vytvořený na základě vstupu uživatele.</returns>
        public List<string> CreateDeck(int choice)
        {
            List<string> deck = new List<string>();

            int startIndex = 0;
            int jokers = 0;

            switch (choice)
            {
                case 1:
                    startIndex = 0;
                    jokers = 0;
                    break;
                case 2:
                    startIndex = 0;
                    jokers = 2;
                    break;
                case 3:
                    startIndex = 0;
                    jokers = 4;
                    break;
                case 4:
                    startIndex = 4;
                    jokers = 0;
                    break;
                case 5:
                    startIndex = 5;
                    jokers = 0;
                    break;
                case 6:
                    startIndex = 7;
                    jokers = 0;
                    break;
            }

            // Generování karet na základě hodnot a barev
            for (int i = startIndex; i < ranks.Count; i++)
            {
                for (int j = 0; j < suits.Count; j++)
                {
                    deck.Add(ranks[i] + " of " + suits[j]);
                }
            }

            // Přidání Jokerů do balíčku
            for (int i = 0; i < jokers; i++)
            {
                deck.Add("Joker");
            }

            return deck;
        }

        /// <summary>
        /// Metoda pro vytáhnutí náhodné karty z daného balíčku.
        /// </summary>
        /// <param name="deck">Balíček karet, ze kterého se má táhnout karta.</param>
        /// <returns>Náhodně vybraná karta z balíčku.</returns>
        public string DrawCard(List<string> deck)
        {
            // Generování náhodného indexu pro výběr karty z balíčku
            int randomIndex = random.Next(deck.Count);
            string randomCard = deck[randomIndex];
            return randomCard;
        }
    }
}
