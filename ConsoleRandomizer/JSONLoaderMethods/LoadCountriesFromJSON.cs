using ConsoleRandomizer.Randomizer.JSON_Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleRandomizer.JSONLoaderMethods
{
    /// <summary>
    /// Třída LoadCountriesFromJSON poskytuje metody pro načítání seznamu zemí z JSON souboru.
    /// </summary>
    public class LoadCountriesFromJSON
    {
        private readonly string countriesPath; // Cesta k JSON souboru se seznamem zemí
        private readonly ErrorController errorController; // Instance třídy pro správu chyb

        /// <summary>
        /// Inicializuje novou instanci třídy LoadCountriesFromJSON s danou cestou k JSON souboru.
        /// </summary>
        /// <param name="path">Cesta k JSON souboru se seznamem zemí.</param>
        public LoadCountriesFromJSON(string path)
        {
            countriesPath = path ?? throw new ArgumentNullException(nameof(path));
            errorController = new ErrorController();
        }

        /// <summary>
        /// Načte data z JSON souboru se seznamem zemí.
        /// </summary>
        /// <param name="filePath">Cesta k JSON souboru. Pokud není zadaná, použije se cesta z konstruktoru.</param>
        /// <param name="exceptionExit">Určuje, zda má dojít k ukončení aplikace při chybě. Výchozí hodnota je true.</param>
        /// <returns>Seznam zemí načtených ze souboru.</returns>
        public List<string> LoadData(string filePath = null, bool exceptionExit = true)
        {
            string path = filePath ?? countriesPath;

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

                // Deserializace JSON obsahu do objektu Countries
                Countries countries = JsonConvert.DeserializeObject<Countries>(jsonContent);

                // Kontrola, zda byla deserializace úspěšná a zda není seznam prázdný
                if (countries == null || countries.CountryList == null || countries.CountryList.Count == 0)
                {
                    throw new Exception("Loaded country list is null or empty.");
                }

                // Kontrola, zda neobsahuje null hodnoty
                if (countries.CountryList.Contains(null))
                {
                    throw new Exception("Loaded country list contains null values.");
                }

                // Vrácení načteného seznamu zemí
                return countries.CountryList;
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
