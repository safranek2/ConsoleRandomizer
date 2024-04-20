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
        /// Zobrazuje uživateli možnosti výběru a provádí odpovídající akce na základě uživatelova vstupu.
        /// </summary>
        public override void Display()
        {
            while (true)
            {
                // Zobrazí uživateli seznam možností výběru
                Console.WriteLine(GetOptions());

                // Vyzve uživatele k zadání volby
                Console.Write("Enter your choice: ");

                string answer = Console.ReadLine();

                // Pokud uživatel zadal platné celé číslo
                if (int.TryParse(answer, out int intAnswer))
                {
                    // Pokud je zadané číslo v rozsahu 1 až 6 (včetně)
                    if (intAnswer >= 1 && intAnswer <= 6)
                    {
                        // Vytvoří balíček karet podle uživatelovy volby
                        List<string> deck = CreateDeck(intAnswer);

                        // Vybere náhodnou kartu z balíčku
                        string randomCard = DrawCard(deck);

                        // Vypíše vybranou náhodnou kartu
                        Console.WriteLine($"Random card: {randomCard}");

                        break; // Ukončí smyčku a vrátí se do hlavního menu
                    }
                    // Pokud uživatel zadal 0 jako volbu ukončení
                    else if (intAnswer == 0)
                    {
                        return; // Ukončí metodu a návrat do hlavního menu
                    }
                    // Pokud uživatel zadal neplatné číslo
                    else
                    {
                        // Vypíše chybové hlášení
                        PrintError("You have entered an invalid number!");
                    }
                }
                // Pokud uživatel nezadal celé číslo
                else
                {
                    // Vypíše chybové hlášení
                    PrintError("You didn't enter a number!");
                }
            }
        }

        /// <summary>
        /// Vrací textový řetězec obsahující seznam dostupných možností pro výběr akce.
        /// </summary>
        /// <returns>Textový řetězec obsahující seznam dostupných možností pro výběr akce.</returns>
        public static string GetOptions()
        {
            // Definuje textový řetězec obsahující seznam možností a jejich popisů
            string options = @"Options:
                    1) Draw a card from the standard 52-card deck
                    2) Draw a card from a 54-card deck with 2 Jokers
                    3) Draw a card from a 56-card deck with 4 Jokers
                    4) Draw a card from a 36-card deck (6-A)
                    5) Draw a card from a 32-card deck (7-A)
                    6) Draw a card from a 24-card deck (9-A)
                    0) Exit";

            return options; // Vrátí textový řetězec s možnostmi
        }

        /// <summary>
        /// Vytvoří balíček karet podle zadaného výběru.
        /// </summary>
        /// <param name="choice">Číslo volby, které určuje typ balíčku, který má být vytvořen.</param>
        /// <returns>Nově vytvořený balíček karet jako seznam řetězců.</returns>
        public List<string> CreateDeck(int choice)
        {
            List<string> deck = new List<string>(); // Inicializuje nový prázdný balíček

            int startIndex = 0; // Index, od kterého začínáme přidávat karty do balíčku
            int jokers = 0; // Počet žolíků v balíčku

            // Podle zadaného výběru nastaví počáteční index a počet žolíků
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

            // Prochází všechny hodnoty karet od zadaného počátečního indexu
            for (int i = startIndex; i < ranks.Count; i++)
            {
                // Pro každou hodnotu karty prochází všechny barvy a přidává je do balíčku
                for (int j = 0; j < suits.Count; j++)
                {
                    deck.Add(ranks[i] + " of " + suits[j]); // Přidá kartu do balíčku ve formátu hodnota "of" barva
                }
            }

            // Přidá žolíky do balíčku podle zadaného počtu
            for (int i = 0; i < jokers; i++)
            {
                deck.Add("Joker"); // Přidá žolíka do balíčku
            }

            return deck; // Vrátí nově vytvořený balíček karet
        }

        /// <summary>
        /// Vybere náhodnou kartu z balíčku a vrátí ji.
        /// </summary>
        /// <param name="deck">Seznam obsahující karty v balíčku.</param>
        /// <returns>Náhodně vybraná karta z balíčku.</returns>
        public string DrawCard(List<string> deck)
        {
            int randomIndex = random.Next(deck.Count); // Vybere náhodný index z rozsahu délky balíčku
            string randomCard = deck[randomIndex]; // Vybere kartu na daném indexu

            return randomCard; // Vrátí vybranou kartu
        }
    }
}
