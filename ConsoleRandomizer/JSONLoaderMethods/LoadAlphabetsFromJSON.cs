using ConsoleRandomizer.Randomizer.JSON_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleRandomizer.JSONLoaderMethods
{
    /// <summary>
    /// Třída LoadAlphabetsFromJSON poskytuje metody pro načítání abeced z JSON souboru.
    /// </summary>
    public class LoadAlphabetsFromJSON
    {
        private string alphabetsPath; // Cesta k JSON souboru s abecedami
        private ErrorController errorController; // Instance třídy pro správu chyb

        /// <summary>
        /// Inicializuje novou instanci třídy LoadAlphabetsFromJSON s danou cestou k JSON souboru.
        /// </summary>
        /// <param name="path">Cesta k JSON souboru s abecedami.</param>
        public LoadAlphabetsFromJSON(string path)
        {
            alphabetsPath = path ?? throw new ArgumentNullException(nameof(path));
            errorController = new ErrorController();
        }

        /// <summary>
        /// Načte data z JSON souboru s abecedami.
        /// </summary>
        /// <param name="filePath">Cesta k JSON souboru. Pokud není zadaná, použije se cesta z konstruktoru.</param>
        /// <param name="exceptionExit">Určuje, zda má dojít k ukončení aplikace při chybě. Výchozí hodnota je true.</param>
        /// <returns>Slovník abeced načtených ze souboru.</returns>
        public Dictionary<string, string> LoadData(string filePath = null, bool exceptionExit = true)
        {
            string path = filePath ?? alphabetsPath;

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

                // Deserializace JSON obsahu do objektu Alphabets
                Alphabets alphabets = JsonConvert.DeserializeObject<Alphabets>(jsonContent);

                // Kontrola, zda byla deserializace úspěšná a zda není slovník prázdný
                if (alphabets == null || alphabets.AlphabetList == null || alphabets.AlphabetList.Count == 0)
                {
                    throw new Exception("Loaded alphabet dictionary is null or empty.");
                }

                // Kontrola, zda neobsahuje prázdné klíče nebo hodnoty
                foreach (var pair in alphabets.AlphabetList)
                {
                    if (string.IsNullOrEmpty(pair.Key) || string.IsNullOrEmpty(pair.Value))
                    {
                        throw new Exception("Loaded alphabet dictionary contains empty keys or values.");
                    }
                }

                // Vrácení načteného slovníku abeced
                return alphabets.AlphabetList;
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
