using ConsoleRandomizer.Randomizer.JSON_Classes;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ConsoleRandomizer.JSONLoaderMethods
{
    /// <summary>
    /// Třída LoadTeamsSettingsFromJSON poskytuje metodu pro načítání nastavení týmů z JSON souboru.
    /// </summary>
    public class LoadTeamsSettingsFromJSON
    {
        private readonly string teamsSettingsPath; // Cesta k JSON souboru s nastavením týmů
        private readonly ErrorController errorController; // Instance třídy pro správu chyb

        /// <summary>
        /// Inicializuje novou instanci třídy LoadTeamsSettingsFromJSON s danou cestou k JSON souboru.
        /// </summary>
        /// <param name="path">Cesta k JSON souboru s nastavením týmů.</param>
        public LoadTeamsSettingsFromJSON(string path)
        {
            teamsSettingsPath = path ?? throw new ArgumentNullException(nameof(path));
            errorController = new ErrorController();
        }

        /// <summary>
        /// Načte data z JSON souboru s nastavením týmů.
        /// </summary>
        /// <param name="filePath">Cesta k JSON souboru. Pokud není zadaná, použije se cesta z konstruktoru.</param>
        /// <param name="exceptionExit">Určuje, zda má dojít k ukončení aplikace při chybě. Výchozí hodnota je true.</param>
        /// <returns>Nastavení týmů načtené ze souboru.</returns>
        public TeamsSettings LoadData(string filePath = null, bool exceptionExit = true)
        {
            string path = filePath ?? teamsSettingsPath;

            try
            {
                // Kontrola, zda je zadaná cesta k souboru
                if (string.IsNullOrEmpty(path))
                {
                    throw new ArgumentNullException(nameof(filePath), "File path cannot be null or empty.");
                }

                // Kontrola, zda soubor existuje
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException($"File not found: {path}");
                }

                // Načtení obsahu souboru
                string jsonContent = File.ReadAllText(path);

                // Deserializace JSON obsahu do objektu TeamsSettings
                TeamsSettings teamsSettings = JsonConvert.DeserializeObject<TeamsSettings>(jsonContent);

                // Kontrola minimálního počtu týmů
                if (teamsSettings.MinTeams < 2)
                {
                    throw new Exception("Minimum number of teams must be at least 2.");
                }

                // Kontrola maximálního počtu týmů
                if (teamsSettings.MaxTeams < teamsSettings.MinTeams)
                {
                    throw new Exception("Maximum number of teams must be greater than or equal to the minimum number of teams.");
                }

                // Vrácení načtených nastavení týmů
                return teamsSettings;
            }
            // Ošetření chyby při neplatné cestě k souboru
            catch (ArgumentNullException ex)
            {
                errorController.PrintError($"Invalid file path: {ex.ParamName}");
            }
            // Ošetření chyby při nenalezení souboru
            catch (FileNotFoundException ex)
            {
                errorController.PrintError(ex.Message);
            }
            // Ošetření obecné chyby při čtení souboru
            catch (Exception ex)
            {
                errorController.PrintError($"Error when reading {path} file: {ex.Message}");
            }

            // Pokud je nastavena volba exceptionExit, ukončí aplikaci
            if (exceptionExit)
            {
                Environment.Exit(0);
            }

            return null;
        }
    }
}
