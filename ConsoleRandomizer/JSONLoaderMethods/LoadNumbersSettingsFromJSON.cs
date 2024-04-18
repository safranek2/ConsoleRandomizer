using ConsoleRandomizer.Randomizer.JSON_Classes;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ConsoleRandomizer.JSONLoaderMethods
{
    /// <summary>
    /// Třída LoadNumbersSettingsFromJSON poskytuje metodu pro načítání nastavení čísel z JSON souboru.
    /// </summary>
    public class LoadNumbersSettingsFromJSON
    {
        private readonly string numbersSettingsPath; // Cesta k JSON souboru s nastavením čísel
        private readonly ErrorController errorController; // Instance třídy pro správu chyb

        /// <summary>
        /// Inicializuje novou instanci třídy LoadNumbersSettingsFromJSON s danou cestou k JSON souboru.
        /// </summary>
        /// <param name="path">Cesta k JSON souboru s nastavením čísel.</param>
        public LoadNumbersSettingsFromJSON(string path)
        {
            numbersSettingsPath = path ?? throw new ArgumentNullException(nameof(path));
            errorController = new ErrorController();
        }

        /// <summary>
        /// Načte data z JSON souboru s nastavením čísel.
        /// </summary>
        /// <param name="filePath">Cesta k JSON souboru. Pokud není zadaná, použije se cesta z konstruktoru.</param>
        /// <param name="exceptionExit">Určuje, zda má dojít k ukončení aplikace při chybě. Výchozí hodnota je true.</param>
        /// <returns>Nastavení čísel načtené ze souboru.</returns>
        public NumbersSettings LoadData(string filePath = null, bool exceptionExit = true)
        {
            string path = filePath ?? numbersSettingsPath;

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

                // Deserializace JSON obsahu do objektu NumbersSettings
                NumbersSettings numbersSettings = JsonConvert.DeserializeObject<NumbersSettings>(jsonContent);

                // Kontrola minimální hodnoty počtu čísel
                if (numbersSettings.MinNumbers < 1)
                {
                    throw new Exception("Minimum number of numbers must be at least 1.");
                }

                // Kontrola platnosti rozsahu počtu čísel
                if (numbersSettings.MaxNumbers < numbersSettings.MinNumbers)
                {
                    throw new Exception("Maximum number of numbers must be greater than or equal to the minimum number of numbers.");
                }

                // Vrácení načteného nastavení čísel
                return numbersSettings;
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
