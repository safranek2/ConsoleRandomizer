using System;

namespace ConsoleRandomizer
{
    /// <summary>
    /// Abstraktní třída pro generátory náhodných prvků.
    /// </summary>
    public abstract class RandomizerBase
    {
        protected readonly Random random = new Random();
        protected readonly ErrorController errorController = new ErrorController();

        /// <summary>
        /// Zobrazí uživatelské rozhraní generátoru.
        /// </summary>
        public abstract void Display();

        /// <summary>
        /// Metoda pro zobrazení chybové zprávy.
        /// </summary>
        /// <param name="errorMessage">Chybová zpráva.</param>
        protected void PrintError(string errorMessage)
        {
            errorController.PrintError(errorMessage);
        }
    }
}
