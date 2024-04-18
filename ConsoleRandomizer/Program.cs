namespace ConsoleRandomizer
{
    /// <summary>
    /// Hlavní třída programu, která obsahuje vstupní metodu pro spuštění aplikace.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Vstupní metoda programu, která se spustí při spuštění aplikace.
        /// </summary>
        /// <param name="args">Argumenty předané programu z příkazové řádky.</param>
        static void Main(string[] args)
        {
            // Vytvoření instance třídy RandomizerMenu pro zobrazení hlavního menu programu
            RandomizerMenu randomizerMenu = new RandomizerMenu();

            // Zobrazení hlavního menu programu pomocí metody Display třídy RandomizerMenu
            randomizerMenu.Display();
        }
    }
}
