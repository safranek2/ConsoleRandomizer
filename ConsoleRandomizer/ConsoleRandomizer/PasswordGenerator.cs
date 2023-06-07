using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleRandomizer
{
    internal class PasswordGenerator
    {
        private Random random = new Random();

        private ErrorController errorController = new ErrorController();

        // Define the character options for the password generator
        private Dictionary<string, string> chars = new Dictionary<string, string>
        {
            { "Upper Case Letters", "ABCDEFGHIJKLMNOPQRSTUVWXYZ" },
            { "Lower Case Letters", "abcdefghijklmnopqrstuvwxyz" },
            { "Numbers", "0123456789" },
            { "Special Signs", "!@#$%^&*()-_=+:;\"'?/,.<>{}[]|\\`~" }
        };

        private int minLength = 4;
        private int maxLength = 35;

        public PasswordGenerator()
        {
        }

        // Display the password generator menu and handle user input
        public void Display()
        {
            int length;

            while (true)
            {
                Console.Write("Enter the length of the password from " + minLength + " to " + maxLength + " or 'exit' to return to the menu: ");
                string answer = Console.ReadLine();
                if (Int32.TryParse(answer, out length))
                {
                    if (length >= minLength && length <= maxLength)
                        break;
                    else
                        errorController.PrintError("You entered a number outside the range of " + minLength + "-" + maxLength + "!");
                }
                else if (answer.Equals("exit"))
                    return;
                else
                    errorController.PrintError("You didn't write a number!");
            }

            // Create a copy of the character options dictionary for password generation
            Dictionary<string, string> passwordChars = new Dictionary<string, string>(chars);
            bool done = false;

            while (true)
            {
                PrintPasswordCharsStatus(passwordChars);

                Console.WriteLine("Options:");
                Console.WriteLine("1) Toggle Upper Case Letters");
                Console.WriteLine("2) Toggle Lower Case Letters");
                Console.WriteLine("3) Toggle Numbers");
                Console.WriteLine("4) Toggle Special Signs");
                Console.WriteLine("5) Generate Password");
                Console.WriteLine("0) Exit");
                Console.Write("Enter your choice or 'exit' to return to the menu: ");

                string answer = Console.ReadLine();

                if (Int32.TryParse(answer, out int intAnswer))
                {
                    if (intAnswer >= 1 && intAnswer <= 4)
                    {
                        // Toggle the selected character option
                        string key = chars.ElementAt(intAnswer - 1).Key;
                        string value = chars.ElementAt(intAnswer - 1).Value;

                        if (passwordChars.ContainsKey(key))
                            passwordChars.Remove(key);
                        else
                            passwordChars.Add(key, value);
                    }
                    else if (intAnswer == 5)
                    {
                        if (passwordChars.Count > 0)
                            break;
                        else
                            errorController.PrintError("You must enable at least one option!");
                    }
                    else if (intAnswer == 0)
                        return;
                    else
                        errorController.PrintError("You didn't enter a valid number!");
                }
                else
                {
                    errorController.PrintError("You didn't enter a number!");
                }
            }

            GeneratePassword(passwordChars, length);
        }

        // Print the status (true or false) of each character option
        public void PrintPasswordCharsStatus(Dictionary<string, string> passwordChars)
        {
            for (int i = 0; i < chars.Count; i++)
            {
                Console.WriteLine(chars.ElementAt(i) + ": " + passwordChars.ContainsKey(chars.ElementAt(i).Key));
            }
        }

        // Generate the password using the selected character options and desired length
        public void GeneratePassword(Dictionary<string, string> passwordChars, int length)
        {
            string password = "";

            for (int i = 0; i < length; i++)
            {
                // Get a random character from one of the enabled character options
                string value = passwordChars.ElementAt(random.Next(0, passwordChars.Count)).Value;
                password += AddChar(value);
            }

            Console.WriteLine("Generated Password: " + password);
        }

        // Add a random character from the provided string of characters
        public char AddChar(string chars)
        {
            return chars[random.Next(0, chars.Length)];
        }
    }
}
