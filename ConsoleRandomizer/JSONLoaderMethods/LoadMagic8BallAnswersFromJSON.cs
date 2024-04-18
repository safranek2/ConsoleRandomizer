using ConsoleRandomizer.Randomizer.JSON_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleRandomizer.JSONLoaderMethods
{
    /// <summary>
    /// Třída LoadMagic8BallAnswersFromJSON poskytuje metody pro načítání odpovědí Magic 8 Ball z JSON souboru.
    /// </summary>
    public class LoadMagic8BallAnswersFromJSON
    {
        private readonly string magic8BallAnswersPath; // Cesta k JSON souboru s odpověďmi Magic 8 Ball
        private readonly ErrorController errorController; // Instance třídy pro správu chyb

        /// <summary>
        /// Inicializuje novou instanci třídy LoadMagic8BallAnswersFromJSON s danou cestou k JSON souboru.
        /// </summary>
        /// <param name="path">Cesta k JSON souboru s odpověďmi Magic 8 Ball.</param>
        public LoadMagic8BallAnswersFromJSON(string path)
        {
            magic8BallAnswersPath = path ?? throw new ArgumentNullException(nameof(path));
            errorController = new ErrorController();
        }

        /// <summary>
        /// Načte data z JSON souboru s odpověďmi Magic 8 Ball.
        /// </summary>
        /// <param name="filePath">Cesta k JSON souboru. Pokud není zadaná, použije se cesta z konstruktoru.</param>
        /// <param name="exceptionExit">Určuje, zda má dojít k ukončení aplikace při chybě. Výchozí hodnota je true.</param>
        /// <returns>Seznam odpovědí Magic 8 Ball načtených ze souboru.</returns>
        public List<string> LoadData(string filePath = null, bool exceptionExit = true)
        {
            string path = filePath ?? magic8BallAnswersPath;

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

                // Deserializace JSON obsahu do objektu Magic8BallAnswers
                Magic8BallAnswers magic8BallAnswers = JsonConvert.DeserializeObject<Magic8BallAnswers>(jsonContent);

                // Kontrola, zda byla deserializace úspěšná a zda není seznam odpovědí prázdný
                if (magic8BallAnswers == null || magic8BallAnswers.Answers == null || magic8BallAnswers.Answers.Count == 0)
                {
                    throw new Exception("Loaded Magic 8 Ball answers list is null or empty.");
                }

                // Kontrola, zda seznam odpovědí neobsahuje null hodnoty
                if (magic8BallAnswers.Answers.Contains(null))
                {
                    throw new Exception("Loaded Magic 8 Ball answers list contains null values.");
                }

                // Vrácení načteného seznamu odpovědí Magic 8 Ball
                return magic8BallAnswers.Answers;
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
