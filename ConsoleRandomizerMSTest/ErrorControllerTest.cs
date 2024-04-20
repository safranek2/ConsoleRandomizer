using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ConsoleRandomizerMSTest
{
    /// <summary>
    /// Testovací třída pro funkčnost třídy ErrorController.
    /// </summary>
    [TestClass]
    public class ErrorControllerTest
    {
        ErrorController errorController; // Instance třídy ErrorController pro testování.

        /// <summary>
        /// Inicializuje instanci třídy ErrorController před spuštěním každého testu.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            errorController = new ErrorController(); // Inicializace instance třídy ErrorController před každým testem.
        }

        /// <summary>
        /// Testuje, zda metoda PrintError vypíše chybovou zprávu do konzole.
        /// </summary>
        [TestMethod]
        public void PrintError_PrintsErrorMessageToConsole()
        {
            // Příprava vstupních dat
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            string errorMessage = "This is an error message.";

            // Provádění testované operace
            errorController.PrintError(errorMessage);
            string consoleOutput = stringWriter.ToString();

            // Kontrola výstupu
            Assert.IsTrue(consoleOutput.Contains(errorMessage));
        }
    }
}
