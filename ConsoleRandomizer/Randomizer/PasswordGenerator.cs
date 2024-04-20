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
    public class PasswordGenerator : RandomizerBase
    {
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

        private readonly Dictionary<string, string> chars; // Slovník pro uchování typů znaků a jejich hodnot.

        private readonly int minLength; // Minimální délka hesla.
        private readonly int maxLength; // Maximální délka hesla.

        /// <summary>
        /// Zobrazuje uživatelské rozhraní pro generování hesla s nastavitelnými znaky a délkou a zpracovává uživatelský vstup.
        /// </summary>
        public override void Display()
        {
            // Kontrola existence a dostupnosti znaků pro heslo
            if (chars != null)
            {
                int length;

                // Získání délky hesla od uživatele
                while (true)
                {
                    Console.Write($"Enter the length of the password from {minLength} to {maxLength} or 'exit' to return to the menu: ");
                    string answer = Console.ReadLine();

                    // Zpracování vstupu uživatele
                    if (Int32.TryParse(answer, out length))
                    {
                        // Kontrola platnosti délky hesla
                        if (length >= minLength && length <= maxLength)
                        {
                            break;
                        }
                        else
                        {
                            PrintError($"You entered a number outside the range of {minLength}-{maxLength} !");
                        }
                    }
                    else if (answer.Equals("exit"))
                    {
                        return;
                    }
                    else
                    {
                        PrintError("You didn't write a number!");
                    }
                }

                // Inicializace slovníku s nastavenými znaky pro heslo
                Dictionary<string, string> passwordChars = new Dictionary<string, string>(chars);

                // Zpracování vstupu uživatele pro nastavení znaků ve slovníku
                while (true)
                {
                    // Získání stavu znaků v hesle pro zobrazení
                    string passwordCharsStatus = ReturnPasswordCharsStatus(passwordChars);
                    Console.WriteLine(passwordCharsStatus);

                    Console.WriteLine("Options:");

                    // Výpis možností pro nastavení znaků ve slovníku
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
                            // Změna stavu znaku v hesle na základě vstupu uživatele
                            string key = chars.ElementAt(intAnswer - 1).Key;
                            string value = chars.ElementAt(intAnswer - 1).Value;

                            if (passwordChars.ContainsKey(key))
                            {
                                passwordChars.Remove(key);
                            }
                            else
                            {
                                passwordChars.Add(key, value);
                            }
                        }
                        else if (intAnswer == chars.Count + 1)
                        {
                            // Kontrola, zda jsou povoleny nějaké znaky pro generování hesla
                            if (passwordChars.Count > 0)
                            {
                                break;
                            }
                            else
                            {
                                PrintError("You must enable at least one option!");
                            }
                        }
                        else if (intAnswer == 0)
                        {
                            return;
                        }
                        else
                        {
                            PrintError("You didn't enter a valid number!");
                        }
                    }
                    else
                    {
                        PrintError("You didn't enter a number!");
                    }
                }

                // Generování hesla na základě nastavených znaků a délky
                string randomPassword = GeneratePassword(passwordChars, length);
                Console.WriteLine($"Generated Password: {randomPassword}");
            }
        }


        /// <summary>
        /// Vytváří textový řetězec popisující stav obsazenosti jednotlivých znaků ve vytvářeném hesle na základě zadaného slovníku znaků a jejich stavů.
        /// </summary>
        /// <param name="passwordChars">Slovník obsahující znaky a jejich stavy (zda jsou nebo nejsou použity ve vytvářeném hesle).</param>
        /// <returns>Textový řetězec popisující stav obsazenosti jednotlivých znaků ve vytvářeném hesle.</returns>
        public string ReturnPasswordCharsStatus(Dictionary<string, string> passwordChars)
        {
            string randomPassword = "";
            // Prochází všechny znaky ve slovníku
            for (int i = 0; i < chars.Count; i++)
            {
                // Vytváří řetězec s informacemi o každém znaku (zda je nebo není použit ve vytvářeném hesle)
                randomPassword += $"{chars.ElementAt(i)}: {passwordChars.ContainsKey(chars.ElementAt(i).Key)}";
            }

            return randomPassword;
        }

        /// <summary>
        /// Generuje heslo na základě zadaného slovníku znaků a jejich stavů a délky hesla.
        /// </summary>
        /// <param name="passwordChars">Slovník obsahující znaky a jejich stavy (zda jsou nebo nejsou použity ve vytvářeném hesle).</param>
        /// <param name="length">Požadovaná délka hesla.</param>
        /// <returns>Vytvořené heslo.</returns>
        public string GeneratePassword(Dictionary<string, string> passwordChars, int length)
        {
            string password = "";

            // Pro každý znak ve vytvářeném hesle
            for (int i = 0; i < length; i++)
            {
                // Získá náhodný znak ze slovníku a jeho hodnotu (char nebo string)
                string value = passwordChars.ElementAt(random.Next(0, passwordChars.Count)).Value;

                // Přidá znak do hesla
                password += GetRandomChar(value);
            }

            return password;
        }

        /// <summary>
        /// Generuje náhodný znak z řetězce znaků.
        /// </summary>
        /// <param name="chars">Řetězec znaků, ze kterého se má vygenerovat náhodný znak.</param>
        /// <returns>Náhodně vybraný znak z daného řetězce.</returns>
        public char GetRandomChar(string chars)
        {
            // Vybere náhodný index v rozsahu délky řetězce
            int randomIndex = random.Next(0, chars.Length);

            // Získá a vrátí znak na daném náhodném indexu
            return chars[randomIndex];
        }
    }
}
