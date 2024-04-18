using ConsoleRandomizer.JSONLoaderMethods;
using ConsoleRandomizer.Randomizer.JSON_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Třída pro načítání dat z JSON souborů.
    /// </summary>
    public class JSONLoader
    {
        /// <summary>
        /// Konstruktor třídy JSONLoader. Inicializuje instance pro načítání různých typů dat.
        /// </summary>
        /// <param name="alphabetsFilePath">Cesta k JSON souboru s abecedami. Pokud není zadána, použije se výchozí cesta.</param>
        /// <param name="countriesFilePath">Cesta k JSON souboru se seznamem zemí. Pokud není zadána, použije se výchozí cesta.</param>
        /// <param name="diceSettingsFilePath">Cesta k JSON souboru s nastavením kostek. Pokud není zadána, použije se výchozí cesta.</param>
        /// <param name="magic8BallAnswersFilePath">Cesta k JSON souboru s odpověďmi kouzelné koule osudu. Pokud není zadána, použije se výchozí cesta.</param>
        /// <param name="numbersSettingsFilePath">Cesta k JSON souboru s nastavením čísel. Pokud není zadána, použije se výchozí cesta.</param>
        /// <param name="passwordSettingsFilePath">Cesta k JSON souboru s nastavením hesel. Pokud není zadána, použije se výchozí cesta.</param>
        /// <param name="teamsSettingsFilePath">Cesta k JSON souboru s nastavením týmů. Pokud není zadána, použije se výchozí cesta.</param>
        public JSONLoader(string alphabetsFilePath = null, string countriesFilePath = null, string diceSettingsFilePath = null,
            string magic8BallAnswersFilePath = null, string numbersSettingsFilePath = null, string passwordSettingsFilePath = null,
            string teamsSettingsFilePath = null)
        {
            // Nastavení cest k JSON souborům
            alphabetsPath = alphabetsFilePath ?? Path.Combine("Resources", "Alphabets.json");
            countriesPath = countriesFilePath ?? Path.Combine("Resources", "Countries.json");
            diceSettingsPath = diceSettingsFilePath ?? Path.Combine("Resources", "DiceSettings.json");
            magic8BallAnswersPath = magic8BallAnswersFilePath ?? Path.Combine("Resources", "Magic8BallAnswers.json");
            numbersSettingsPath = numbersSettingsFilePath ?? Path.Combine("Resources", "NumbersSettings.json");
            passwordSettingsPath = passwordSettingsFilePath ?? Path.Combine("Resources", "PasswordSettings.json");
            teamsSettingsPath = teamsSettingsFilePath ?? Path.Combine("Resources", "TeamsSettings.json");

            // Inicializace instancí pro načítání dat
            loadAlphabetsFromJSON = new LoadAlphabetsFromJSON(alphabetsPath);
            loadCountriesFromJSON = new LoadCountriesFromJSON(countriesPath);
            loadDiceSettingsFromJSON = new LoadDiceSettingsFromJSON(diceSettingsPath);
            loadMagic8BallAnswersFromJSON = new LoadMagic8BallAnswersFromJSON(magic8BallAnswersPath);
            loadNumbersSettingsFromJSON = new LoadNumbersSettingsFromJSON(numbersSettingsPath);
            loadPasswordSettingsFromJSON = new LoadPasswordSettingsFromJSON(passwordSettingsPath);
            loadTeamsSettingsFromJSON = new LoadTeamsSettingsFromJSON(teamsSettingsPath);
        }

        // Cesty k JSON souborům
        private readonly string alphabetsPath;
        private readonly string countriesPath;
        private readonly string diceSettingsPath;
        private readonly string magic8BallAnswersPath;
        private readonly string numbersSettingsPath;
        private readonly string passwordSettingsPath;
        private readonly string teamsSettingsPath;

        // Instance tříd pro načítání dat
        private LoadAlphabetsFromJSON loadAlphabetsFromJSON;
        private LoadCountriesFromJSON loadCountriesFromJSON;
        private LoadDiceSettingsFromJSON loadDiceSettingsFromJSON;
        private LoadMagic8BallAnswersFromJSON loadMagic8BallAnswersFromJSON;
        private LoadNumbersSettingsFromJSON loadNumbersSettingsFromJSON;
        private LoadPasswordSettingsFromJSON loadPasswordSettingsFromJSON;
        private LoadTeamsSettingsFromJSON loadTeamsSettingsFromJSON;

        /// <summary>
        /// Metoda pro načtení abeced z JSON souboru.
        /// </summary>
        /// <param name="filePath">Cesta k JSON souboru s abecedami. Pokud není zadána, použije se výchozí cesta.</param>
        /// <param name="exceptionExit">Určuje, zda má dojít k ukončení aplikace při chybě. Výchozí hodnota je true.</param>
        /// <returns>Slovník abeced načtených ze souboru.</returns>
        public Dictionary<string, string> LoadAlphabetsFromJSON(string filePath = null, bool exceptionExit = true)
        {
            Dictionary<string, string> result = loadAlphabetsFromJSON.LoadData(filePath, exceptionExit);
            return result;
        }

        /// <summary>
        /// Metoda pro načtení seznamu zemí z JSON souboru.
        /// </summary>
        /// <param name="filePath">Cesta k JSON souboru se seznamem zemí. Pokud není zadána, použije se výchozí cesta.</param>
        /// <param name="exceptionExit">Určuje, zda má dojít k ukončení aplikace při chybě. Výchozí hodnota je true.</param>
        /// <returns>Seznam zemí načtený ze souboru.</returns>
        public List<string> LoadCountriesFromJSON(string filePath = null, bool exceptionExit = true)
        {
            List<string> result = loadCountriesFromJSON.LoadData(filePath, exceptionExit);
            return result;
        }

        /// <summary>
        /// Metoda pro načtení nastavení kostek z JSON souboru.
        /// </summary>
        /// <param name="filePath">Cesta k JSON souboru s nastavením kostek. Pokud není zadána, použije se výchozí cesta.</param>
        /// <param name="exceptionExit">Určuje, zda má dojít k ukončení aplikace při chybě. Výchozí hodnota je true.</param>
        /// <returns>Nastavení kostek načtené ze souboru.</returns>
        public DiceSettings LoadDiceSettingsFromJSON(string filePath = null, bool exceptionExit = true)
        {
            DiceSettings result = loadDiceSettingsFromJSON.LoadData(filePath, exceptionExit);
            return result;
        }

        /// <summary>
        /// Metoda pro načtení odpovědí kouzelné koule osudu z JSON souboru.
        /// </summary>
        /// <param name="filePath">Cesta k JSON souboru s odpověďmi kouzelné koule osudu. Pokud není zadána, použije se výchozí cesta.</param>
        /// <param name="exceptionExit">Určuje, zda má dojít k ukončení aplikace při chybě. Výchozí hodnota je true.</param>
        /// <returns>Seznam odpovědí načtený ze souboru.</returns>
        public List<string> LoadMagic8BallAnswersFromJSON(string filePath = null, bool exceptionExit = true)
        {
            List<string> result = loadMagic8BallAnswersFromJSON.LoadData(filePath, exceptionExit);
            return result;
        }

        /// <summary>
        /// Metoda pro načtení nastavení čísel z JSON souboru.
        /// </summary>
        /// <param name="filePath">Cesta k JSON souboru s nastavením čísel. Pokud není zadána, použije se výchozí cesta.</param>
        /// <param name="exceptionExit">Určuje, zda má dojít k ukončení aplikace při chybě. Výchozí hodnota je true.</param>
        /// <returns>Nastavení čísel načtené ze souboru.</returns>
        public NumbersSettings LoadNumbersSettingsFromJSON(string filePath = null, bool exceptionExit = true)
        {
            NumbersSettings result = loadNumbersSettingsFromJSON.LoadData(filePath, exceptionExit);
            return result;
        }

        /// <summary>
        /// Metoda pro načtení nastavení hesel z JSON souboru.
        /// </summary>
        /// <param name="filePath">Cesta k JSON souboru s nastavením hesel. Pokud není zadána, použije se výchozí cesta.</param>
        /// <param name="exceptionExit">Určuje, zda má dojít k ukončení aplikace při chybě. Výchozí hodnota je true.</param>
        /// <returns>Nastavení hesel načtené ze souboru.</returns>
        public PasswordSettings LoadPasswordSettingsFromJSON(string filePath = null, bool exceptionExit = true)
        {
            PasswordSettings result = loadPasswordSettingsFromJSON.LoadData(filePath, exceptionExit);
            return result;
        }

        /// <summary>
        /// Metoda pro načtení nastavení týmů z JSON souboru.
        /// </summary>
        /// <param name="filePath">Cesta k JSON souboru s nastavením týmů. Pokud není zadána, použije se výchozí cesta.</param>
        /// <param name="exceptionExit">Určuje, zda má dojít k ukončení aplikace při chybě. Výchozí hodnota je true.</param>
        /// <returns>Nastavení týmů načtené ze souboru.</returns>
        public TeamsSettings LoadTeamsSettingsFromJSON(string filePath = null, bool exceptionExit = true)
        {
            TeamsSettings result = loadTeamsSettingsFromJSON.LoadData(filePath, exceptionExit);
            return result;
        }
    }
}
