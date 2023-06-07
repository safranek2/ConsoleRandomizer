using System;
using System.Collections.Generic;

namespace ConsoleRandomizer
{
    internal class CardGenerator
    {
        public CardGenerator()
        {
        }

        private ErrorController errorController = new ErrorController();

        private Random random = new Random();

        // List of card ranks
        private List<string> ranks = new List<string>()
        {
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine",
            "Ten",
            "Jack",
            "Queen",
            "King",
            "Ace",
        };

        // List of card suits
        private List<string> suits = new List<string>()
        {
            "Clubs",
            "Diamonds",
            "Hearts",
            "Spades"
        };

        // Display the card generator menu and handle user input
        public void Display()
        {
            while (true)
            {
                Console.WriteLine("Options:");
                Console.WriteLine("1) Draw card from a standard 52-card deck");
                Console.WriteLine("2) Draw card from a 54-card deck with 2 Jokers");
                Console.WriteLine("3) Draw card from a 56-card deck with 4 Jokers");
                Console.WriteLine("4) Draw card from a 36-card deck (6-A)");
                Console.WriteLine("5) Draw card from a 32-card deck (7-A)");
                Console.WriteLine("6) Draw card from a 24-card deck (9-A)");
                Console.WriteLine("0) Exit");

                Console.Write("Enter your choice: ");
                string answer = Console.ReadLine();

                if (int.TryParse(answer, out int intAnswer))
                {
                    if (intAnswer >= 1 && intAnswer <= 6)
                    {
                        List<string> deck = CreateDeck(intAnswer);
                        DrawCard(deck);
                        break;
                    }
                    else if (intAnswer == 0)
                    {
                        return;
                    }
                    else
                    {
                        errorController.PrintError("You entered an invalid number!");
                    }
                }
                else
                {
                    errorController.PrintError("You didn't enter a number!");
                }
            }
        }

        // Create a deck of cards based on the user's choice
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

            // Generate cards based on ranks and suits
            for (int i = startIndex; i < ranks.Count; i++)
            {
                for (int j = 0; j < suits.Count; j++)
                {
                    deck.Add(ranks[i] + " of " + suits[j]);
                }
            }

            // Add jokers to the deck
            for (int i = 0; i < jokers; i++)
            {
                deck.Add("Joker");
            }

            return deck;
        }

        // Draw a random card from the given deck
        public void DrawCard(List<string> deck)
        {
            // Generate a random index to pick a card from the deck
            int randomIndex = random.Next(deck.Count);
            string randomCard = deck[randomIndex];
            Console.WriteLine("Random card: " + randomCard);
        }
    }
}
