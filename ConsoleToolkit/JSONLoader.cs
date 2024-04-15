using ConsoleToolkit.Randomizer.JSON_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleToolkit
{
    /// <summary>
    /// Třída pro načítání dat ze souborů ve formátu JSON.
    /// </summary>
    internal class JSONLoader
    {
        private readonly ErrorController errorController = new ErrorController(); // Instance třídy pro správu chyb
        private readonly string countriesPath = Path.Combine("Resources", "Countries.json"); // Cesta k JSON souboru se zeměmi
        private readonly string dicesSettingsPath = Path.Combine("Resources", "DicesSettings.json"); // Cesta k JSON souboru s nastavením kostek
        private readonly string alphabetsPath = Path.Combine("Resources", "Alphabets.json"); // Cesta k JSON souboru s abecedami
        private readonly string magic8BallAnswersPath = Path.Combine("Resources", "Magic8BallAnswers.json"); // Cesta k JSON souboru s odpověďmi Magic 8 Ball
        private readonly string numbersSettingsPath = Path.Combine("Resources", "NumbersSettings.json"); // Cesta k JSON souboru s nastavením čísel
        private readonly string passwordSettingsPath = Path.Combine("Resources", "PasswordSettings.json"); // Cesta k JSON souboru s nastavením hesla
        private readonly string teamsSettingsPath = Path.Combine("Resources", "TeamsSettings.json"); // Cesta k JSON souboru s nastavením teamů

        /// <summary>
        /// Metoda pro načítání seznamu zemí ze souboru ve formátu JSON.
        /// </summary>
        /// <returns>Seznam zemí nebo null v případě chyby.</returns>
        public List<string> LoadCountriesFromJSON()
        {
            try
            {
                // Načtení obsahu souboru do textového řetězce
                string jsonContent = File.ReadAllText(countriesPath);

                // Deserializace JSON obsahu do objektu třídy Countries
                Countries countries = JsonConvert.DeserializeObject<Countries>(jsonContent);

                // Vrácení seznamu zemí z objektu Countries
                return countries.CountryList;
            }
            catch (Exception ex)
            {
                // Pokud došlo k chybě při načítání souboru, vypiš chybovou zprávu a vrať null
                errorController.PrintError($"Error when reading a file: {ex.Message}");
                Environment.Exit(0);
                return null;
            }
        }

        /// <summary>
        /// Metoda pro načítání nastavení pro házení kostek ze souboru ve formátu JSON.
        /// </summary>
        /// <returns>Objekt DiceSettings obsahující nastavení kostek nebo null v případě chyby.</returns>
        public DiceSettings LoadDicesSettingsFromJSON()
        {
            try
            {
                // Načtení obsahu souboru do textového řetězce
                string jsonContent = File.ReadAllText(dicesSettingsPath);

                // Deserializace JSON obsahu do objektu třídy DiceSettings
                DiceSettings dicesSettings = JsonConvert.DeserializeObject<DiceSettings>(jsonContent);

                return dicesSettings;
            }
            catch (Exception ex)
            {
                // Pokud došlo k chybě při načítání souboru, vypiš chybovou zprávu a vrať null
                errorController.PrintError($"Error when reading a file: {ex.Message}");
                Environment.Exit(0);
                return null;
            }
        }

        /// <summary>
        /// Metoda pro načítání abeced ze souboru ve formátu JSON.
        /// </summary>
        /// <returns>Slovník obsahující abecedy nebo null v případě chyby.</returns>
        public Dictionary<string, string> LoadAlphabetsFromJSON()
        {
            try
            {
                // Načtení obsahu souboru do textového řetězce
                string jsonContent = File.ReadAllText(alphabetsPath);

                // Deserializace JSON obsahu do slovníku abeced
                Alphabets alphabets = JsonConvert.DeserializeObject<Alphabets>(jsonContent);

                return alphabets.AlphabetList;
            }
            catch (Exception ex)
            {
                // Pokud došlo k chybě při načítání souboru, vypiš chybovou zprávu a vrať null
                errorController.PrintError($"Error when reading a file: {ex.Message}");
                Environment.Exit(0);
                return null;
            }
        }

        /// <summary>
        /// Metoda pro načítání odpovědí Magic 8 Ball ze souboru ve formátu JSON.
        /// </summary>
        /// <returns>Seznam možných odpovědí Magic 8 Ball nebo null v případě chyby.</returns>
        public List<string> LoadMagic8BallAnswersFromJSON()
        {
            try
            {
                // Načtení obsahu souboru do textového řetězce
                string jsonContent = File.ReadAllText(magic8BallAnswersPath);

                // Deserializace JSON obsahu do objektu třídy Magic8BallAnswers
                Magic8BallAnswers magic8BallAnswers = JsonConvert.DeserializeObject<Magic8BallAnswers>(jsonContent);

                return magic8BallAnswers.Answers;
            }
            catch (Exception ex)
            {
                // Pokud došlo k chybě při načítání souboru, vypiš chybovou zprávu a vrať null
                errorController.PrintError($"Error when reading a file: {ex.Message}");
                Environment.Exit(0);
                return null;
            }
        }

        /// <summary>
        /// Metoda pro načítání nastavení čísel ze souboru ve formátu JSON.
        /// </summary>
        /// <returns>Maximální počet čísel nebo -1 v případě chyby.</returns>
        public int LoadNumbersSettingsFromJSON()
        {
            try
            {
                // Načtení obsahu souboru do textového řetězce
                string jsonContent = File.ReadAllText(numbersSettingsPath);

                // Deserializace JSON obsahu do objektu třídy Numbers
                NumbersSettings numbersSettings = JsonConvert.DeserializeObject<NumbersSettings>(jsonContent);

                return numbersSettings.MaxNumbers;
            }
            catch (Exception ex)
            {
                // Pokud došlo k chybě při načítání souboru, vypiš chybovou zprávu a vrať -1
                errorController.PrintError($"Error when reading a file: {ex.Message}");
                Environment.Exit(0);
                return -1;
            }
        }

        /// <summary>
        /// Metoda pro načítání nastavení hesla ze souboru ve formátu JSON.
        /// </summary>
        /// <returns>Objekt PasswordSettings obsahující nastavení hesla nebo null v případě chyby.</returns>
        public PasswordSettings LoadPasswordSettingsFromJSON()
        {
            try
            {
                string jsonContent = File.ReadAllText(passwordSettingsPath);
                PasswordSettings passwordSettings = JsonConvert.DeserializeObject<PasswordSettings>(jsonContent);
                return passwordSettings;
            }
            catch (Exception ex)
            {
                errorController.PrintError($"Error when reading a file: {ex.Message}");
                Environment.Exit(0);
                return null;
            }
        }

        /// <summary>
        /// Metoda pro načítání nastavení týmů ze souboru ve formátu JSON.
        /// </summary>
        /// <returns>Objekt TeamsSettings obsahující nastavení hesla nebo null v případě chyby.</returns>
        public TeamsSettings LoadTeamsSettingsFromJSON()
        {
            try
            {
                string jsonContent = File.ReadAllText(teamsSettingsPath);
                TeamsSettings teamsSettings = JsonConvert.DeserializeObject<TeamsSettings>(jsonContent);
                return teamsSettings;
            }
            catch (Exception ex)
            {
                errorController.PrintError($"Error when reading a file: {ex.Message}");
                Environment.Exit(0);
                return null;
            }
        }
    }
}
