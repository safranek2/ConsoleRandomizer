using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleRandomizer
{
    internal class LetterGenerator
    {
        private Random random = new Random();

        private ErrorController errorController = new ErrorController();

        // Define the dictionary of language alphabets
        private Dictionary<string, string> alphabets = new Dictionary<string, string>()
        {
            { "English", "ABCDEFGHIJKLMNOPQRSTUVWXYZ" },
            { "French", "ABCDEFGHIJKLMNOPQRSTUVWXYZÀÂÆÇÉÈÊËÎÏÔŒÙÛÜŸ" },
            { "German", "ABCDEFGHIJKLMNOPQRSTUVWXYZÄÖÜß" },
            { "Polish", "AĄBCĆDEĘFGHIJKLŁMNŃOÓPRSŚTUWYZŹŻ" },
            { "Portuguese", "ABCDEFGHIJKLMNOPQRSTUVWXYZÁÀÂÃÉÊÍÓÔÕÚÜÇ" },
            { "Romanian", "AĂÂBCDEFGHIÎJKLMNOPQRSȘTȚUVWXYZ" },
            { "Russian", "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ" },
            { "Slovak", "AÁÄBCČDĎEÉĚFGHIÍJKLMNŇOÓÔPQRŘŔSŠTŤUÚŮVWXYÝZŽ" },
            { "Spanish", "ABCDEFGHIJKLMNÑOPQRSTUVWXYZÁÉÍÓÚÜ" },
            { "Turkish", "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ" },
            { "Ukrainian", "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ" }
        };

        public LetterGenerator()
        {
        }

        // Display the letter generator menu and handle user input
        public void Display()
        {
            // Display the available languages to the user
            Console.WriteLine("Available languages: ");
            for (int i = 0; i < alphabets.Count; i++)
            {
                Console.WriteLine((i + 1) + ") " + alphabets.ElementAt(i).Key);
            }

            int intAnswer;
            while (true)
            {
                Console.Write("Enter your choice or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();

                if (Int32.TryParse(answer, out intAnswer))
                {
                    if (intAnswer > 0 && intAnswer <= alphabets.Count)
                        break;
                    else
                        errorController.PrintError("You entered a number outside the range of 1-" + alphabets.Count + "!");
                }
                else if (answer.Equals("exit"))
                {
                    return;
                }
                else
                {
                    errorController.PrintError("You did not enter a valid number!");
                }
            }

            // Retrieve the selected alphabet based on the user's choice
            string selectedAlphabet = alphabets.ElementAt(intAnswer - 1).Value;

            char randomChar = GetChar(selectedAlphabet);
            Console.WriteLine("Random letter: " + randomChar);
        }

        // Get a random character from a given set of characters
        private char GetChar(string chars)
        {
            return chars[random.Next(chars.Length)];
        }
    }
}
