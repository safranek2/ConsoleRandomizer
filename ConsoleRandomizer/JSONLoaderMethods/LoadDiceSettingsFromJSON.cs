using ConsoleRandomizer.Randomizer.JSON_Classes;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ConsoleRandomizer.JSONLoaderMethods
{
    /// <summary>
    /// Třída LoadDiceSettingsFromJSON poskytuje metody pro načítání nastavení pro házení kostek z JSON souboru.
    /// </summary>
    public class LoadDiceSettingsFromJSON
    {
        private readonly string diceSettingsPath; // Cesta k JSON souboru s nastavením pro házení kostek
        private readonly ErrorController errorController; // Instance třídy pro správu chyb

        /// <summary>
        /// Inicializuje novou instanci třídy LoadDiceSettingsFromJSON s danou cestou k JSON souboru.
        /// </summary>
        /// <param name="path">Cesta k JSON souboru s nastavením pro házení kostek.</param>
        public LoadDiceSettingsFromJSON(string path)
        {
            diceSettingsPath = path ?? throw new ArgumentNullException(nameof(path));
            errorController = new ErrorController();
        }

        /// <summary>
        /// Načte data z JSON souboru s nastavením pro házení kostek.
        /// </summary>
        /// <param name="filePath">Cesta k JSON souboru. Pokud není zadaná, použije se cesta z konstruktoru.</param>
        /// <param name="exceptionExit">Určuje, zda má dojít k ukončení aplikace při chybě. Výchozí hodnota je true.</param>
        /// <returns>Objekt obsahující nastavení pro házení kostek načtené ze souboru.</returns>
        public DiceSettings LoadData(string filePath = null, bool exceptionExit = true)
        {
            string path = filePath ?? diceSettingsPath;

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

                // Deserializace JSON obsahu do objektu DiceSettings
                DiceSettings diceSettings = JsonConvert.DeserializeObject<DiceSettings>(jsonContent);

                // Kontrola, zda byla deserializace úspěšná
                if (diceSettings == null)
                {
                    throw new Exception("Loaded dice settings are null.");
                }

                // Kontrola minimálního počtu kostek
                if (diceSettings.MinDice < 1)
                {
                    throw new Exception("Minimum number of dice must be at least 1.");
                }

                // Kontrola, zda maximální počet kostek je větší nebo roven minimálnímu počtu kostek
                if (diceSettings.MaxDice < diceSettings.MinDice)
                {
                    throw new Exception("Maximum number of dice must be greater than or equal to the minimum number of dice.");
                }

                // Kontrola minimálního počtu stran na kostce
                if (diceSettings.MinSides < 3)
                {
                    throw new Exception("Minimum number of sides on each die must be at least 3.");
                }

                // Kontrola, zda maximální počet stran na kostce je větší nebo roven minimálnímu počtu stran na kostce
                if (diceSettings.MaxSides < diceSettings.MinSides)
                {
                    throw new Exception("Maximum number of sides on each die must be greater than or equal to the minimum number of sides.");
                }

                // Vrácení načteného nastavení pro házení kostek
                return diceSettings;
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
