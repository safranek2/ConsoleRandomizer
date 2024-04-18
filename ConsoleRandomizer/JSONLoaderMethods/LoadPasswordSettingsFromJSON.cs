using ConsoleRandomizer.Randomizer.JSON_Classes;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace ConsoleRandomizer.JSONLoaderMethods
{
    /// <summary>
    /// Třída LoadPasswordSettingsFromJSON poskytuje metodu pro načítání nastavení hesel z JSON souboru.
    /// </summary>
    public class LoadPasswordSettingsFromJSON
    {
        private readonly string passwordSettingsPath; // Cesta k JSON souboru s nastavením hesel
        private readonly ErrorController errorController; // Instance třídy pro správu chyb

        /// <summary>
        /// Inicializuje novou instanci třídy LoadPasswordSettingsFromJSON s danou cestou k JSON souboru.
        /// </summary>
        /// <param name="path">Cesta k JSON souboru s nastavením hesel.</param>
        public LoadPasswordSettingsFromJSON(string path)
        {
            passwordSettingsPath = path ?? throw new ArgumentNullException(nameof(path));
            errorController = new ErrorController();
        }

        /// <summary>
        /// Načte data z JSON souboru s nastavením hesel.
        /// </summary>
        /// <param name="filePath">Cesta k JSON souboru. Pokud není zadaná, použije se cesta z konstruktoru.</param>
        /// <param name="exceptionExit">Určuje, zda má dojít k ukončení aplikace při chybě. Výchozí hodnota je true.</param>
        /// <returns>Nastavení hesel načtené ze souboru.</returns>
        public PasswordSettings LoadData(string filePath = null, bool exceptionExit = true)
        {
            string path = filePath ?? passwordSettingsPath;

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

                // Deserializace JSON obsahu do objektu PasswordSettings
                PasswordSettings passwordSettings = JsonConvert.DeserializeObject<PasswordSettings>(jsonContent);

                // Kontrola minimální hodnoty počtu znaků
                if (passwordSettings.MinChars < 1)
                {
                    throw new Exception("Minimum number of characters must be at least 1.");
                }

                // Kontrola platnosti rozsahu počtu znaků
                if (passwordSettings.MaxChars < passwordSettings.MinChars)
                {
                    throw new Exception("Maximum number of characters must be greater than or equal to the minimum number of characters.");
                }

                // Kontrola, zda seznam chars není null, není prázdný a neobsahuje null nebo prázdné položky
                if (passwordSettings.Chars != null && passwordSettings.Chars.Any() && !passwordSettings.Chars.Any(c => c == null || string.IsNullOrEmpty(c.Name) || string.IsNullOrEmpty(c.Characters)))
                {
                    return passwordSettings;
                }
                else
                {
                    // Vypíše chybu, když seznam chars obsahuje null nebo prázdné položky
                    errorController.PrintError("Loaded password settings contain null or empty characters.");
                }
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
