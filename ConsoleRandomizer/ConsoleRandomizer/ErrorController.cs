using System;

namespace ConsoleRandomizer
{
    internal class ErrorController
    {
        public ErrorController()
        {
        }

        // Print an error message in red color
        public void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);

            // Reset console color to default
            Console.ResetColor();
        }
    }
}
