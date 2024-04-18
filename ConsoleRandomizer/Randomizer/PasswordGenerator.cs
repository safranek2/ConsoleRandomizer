using ConsoleRandomizer.Randomizer.JSON_Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Třída pro generování hesel s použitím nastavení uloženého v JSON souboru.
    /// </summary>
    public class PasswordGenerator
    {
        private readonly Random random = new Random(); // Instance třídy pro generování náhodných čísel.
        private readonly ErrorController errorController = new ErrorController(); // Instance třídy pro zpracování chyb.
        private readonly Dictionary<string, string> chars; // Slovník pro uchování typů znaků a jejich hodnot.

        private readonly int minLength; // Minimální délka hesla.
        private readonly int maxLength; // Maximální délka hesla.

        /// <summary>
        /// Konstruktor třídy PasswordGenerator. Načte nastavení hesla z JSON souboru.
        /// </summary>
        public PasswordGenerator()
        {
            JSONLoader jsonLoader = new JSONLoader(); // Instance třídy pro načítání JSON souborů.
            PasswordSettings passwordSettings = jsonLoader.LoadPasswordSettingsFromJSON(); // Načtení nastavení hesla z JSON souboru.

            // Inicializace minimální a maximální délky hesla podle načtených hodnot z JSON souboru.
            minLength = passwordSettings.MinChars;
            maxLength = passwordSettings.MaxChars;

            // Naplnění slovníku chars podle načtených hodnot z JSON souboru.
            chars = passwordSettings.Chars.ToDictionary(item => item.Name, item => item.Characters);
        }

        /// <summary>
        /// Zobrazí uživatelské rozhraní pro generování hesla.
        /// </summary>
        public void Display()
        {
            // Zkontroluje, zda seznam znaků není prázdný a obsahuje alespoň jeden prvek
            if (chars != null)
            {
                int length;

                while (true)
                {
                    // Výzva k zadání délky hesla uživatelem.
                    Console.Write($"Enter the length of the password from {minLength} to {maxLength} or 'exit' to return to the menu: ");
                    string answer = Console.ReadLine();

                    // Pokud uživatel zadal číslo...
                    if (Int32.TryParse(answer, out length))
                    {
                        // Pokud je délka v rozmezí min a max délky, ukonči smyčku.
                        if (length >= minLength && length <= maxLength)
                            break;
                        else
                            errorController.PrintError($"You entered a number outside the range of {minLength}-{maxLength} !");
                    }
                    // Pokud uživatel zadal "exit", vrať se zpět do menu.
                    else if (answer.Equals("exit"))
                        return;
                    else
                        errorController.PrintError("You didn't write a number!");
                }

                // Vytvoření kopie slovníku znaků pro heslo.
                Dictionary<string, string> passwordChars = new Dictionary<string, string>(chars);

                while (true)
                {
                    PrintPasswordCharsStatus(passwordChars); // Výpis aktuálního stavu vybraných znaků.

                    Console.WriteLine("Options:");

                    for (int i = 0; i < chars.Count; i++)
                    {
                        string key = chars.ElementAt(i).Key;
                        Console.WriteLine($"{i + 1}) Toggle {key}");
                    }

                    Console.WriteLine($"{chars.Count + 1}) Generate Password");
                    Console.WriteLine("0) Exit");
                    Console.Write("Enter your choice or 'exit' to return to the menu: ");

                    string answer = Console.ReadLine();

                    if (Int32.TryParse(answer, out int intAnswer))
                    {
                        if (intAnswer >= 1 && intAnswer <= chars.Count)
                        {
                            string key = chars.ElementAt(intAnswer - 1).Key;
                            string value = chars.ElementAt(intAnswer - 1).Value;

                            // Přidání nebo odebrání vybraných znaků ze slovníku pro heslo.
                            if (passwordChars.ContainsKey(key))
                                passwordChars.Remove(key);
                            else
                                passwordChars.Add(key, value);
                        }
                        else if (intAnswer == chars.Count + 1)
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

                GeneratePassword(passwordChars, length); // Generování hesla na základě vybraných znaků a délky.
            }
        }

        /// <summary>
        /// Vypíše aktuální stav vybraných znaků pro heslo.
        /// </summary>
        /// <param name="passwordChars">Slovník vybraných znaků pro heslo.</param>
        public void PrintPasswordCharsStatus(Dictionary<string, string> passwordChars)
        {
            for (int i = 0; i < chars.Count; i++)
            {
                Console.WriteLine($"{chars.ElementAt(i)}: {passwordChars.ContainsKey(chars.ElementAt(i).Key)}");
            }
        }

        /// <summary>
        /// Generuje heslo na základě vybraných znaků a délky.
        /// </summary>
        /// <param name="passwordChars">Slovník vybraných znaků pro heslo.</param>
        /// <param name="length">Délka hesla.</param>
        public void GeneratePassword(Dictionary<string, string> passwordChars, int length)
        {
            string password = "";

            for (int i = 0; i < length; i++)
            {
                string value = passwordChars.ElementAt(random.Next(0, passwordChars.Count)).Value;
                password += AddChar(value);
            }

            Console.WriteLine($"Generated Password: {password}");
        }

        /// <summary>
        /// Přidá náhodný znak z daného řetězce znaků.
        /// </summary>
        /// <param name="chars">Řetězec znaků.</param>
        /// <returns>Náhodně vybraný znak.</returns>
        public char AddChar(string chars)
        {
            return chars[random.Next(0, chars.Length)];
        }
    }
}
